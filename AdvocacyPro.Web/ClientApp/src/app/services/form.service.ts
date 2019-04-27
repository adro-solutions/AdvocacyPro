import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, FormArray, Validators } from '@angular/forms';
import { ValuesService } from './values.service';
import { HttpClient } from '@angular/common/http';
import { ZipCodesService } from './zipCodes.service';
import { Observable, Subject } from 'rxjs';
import { UIHint } from '../models/uiHint.model';
import { Feature } from '../models/feature.model';
import { CustomValidators } from './customValidators';

@Injectable({ providedIn: 'root' })
export class FormService {
    attributes: any;

    constructor(private fb: FormBuilder, private httpService: HttpClient, private zipService: ZipCodesService,
        private vService: ValuesService) {
        this.attributes = {};
    }

    buildFormGroup<T>(obj: T, typeName: string): Observable<FormGroup> {
        const group: any = {};
        const subj = new Subject<FormGroup>();

        this.httpService.get<any>(`api/Object/${typeName}/ValidationInfo`).subscribe(propertyValidations => {
            this.attributes[typeName] = propertyValidations;

            for (const key of Object.keys(obj)) {
                const propAttributes = propertyValidations.filter(prop => prop.key.toLowerCase() === key.toLowerCase());
                const uiHints: Array<UIHint> = propAttributes.filter(prop => prop.value.type === 'uiHint')
                                                           .map(prop => prop.value);

                const validations = new Array<any>();
                this.buildValidationArray(validations, propAttributes);


                if (uiHints.length === 1) {
                    const uiHint = uiHints[0];
                    let controls: Array<FormControl>;
                    const values = this.vService[uiHint.valuesFunction];

                    controls = values.map(v => {
                        return this.fb.control(obj[key].filter(o => o[uiHint.childKey] === v.id ).length > 0);
                    });

                    const fa = new FormArray(controls, validations);

                    group[key] = fa;
                } else {
                    const fc = new FormControl();
                    fc.setValue(obj[key]);

                    if (propAttributes.length >= 1) {
                        fc.setValidators(validations);
                        fc.displayName = propAttributes[0].value.displayName;
                    }

                    group[key] = fc;
                }
            }

            subj.next(this.fb.group(group));
        });

        return subj.asObservable();
    }

    buildFormGroupFromArray(array: Feature[], selected: Feature[], arrayPropertyName: string, selectedPropertyName: string): FormGroup {
        const group: any = {};
        for (let i = 0; i < array.length; i++) {
            if (selected.filter(s => s[selectedPropertyName] === array[i][arrayPropertyName]).length > 0) {
                const fc = new FormControl();
                fc.setValue(true);
                group[array[i][arrayPropertyName]] = fc;
            } else {
                group[array[i][arrayPropertyName]] = new FormControl();
            }
        }

        return this.fb.group(group);
    }

    private buildValidationArray(collection: Array<any>, propertyAttributes: Array<any>) {
        for (const propAttribute of propertyAttributes) {
            switch (propAttribute.value.type.toLowerCase()) {
                case 'required': collection.push(Validators.required); break;
                case 'maxlength': collection.push(Validators.maxLength(propAttribute.value.length)); break;
                case 'minlength': collection.push(Validators.minLength(propAttribute.value.length)); break;
                case 'range': collection.push(CustomValidators.range(propAttribute.value.minValue, propAttribute.value.maxValue));
                    break;
                case 'email': collection.push(CustomValidators.email); break;
                case 'phone': collection.push(CustomValidators.phone('US')); break;
                case 'regex': collection.push(Validators.pattern(propAttribute.value.pattern)); break;
            }
        }
    }

    completeZip(form: FormGroup) {
        if (!form.value['city'] || !form.value['stateId']) {
            if (form.value['zipCode'].length >= 5) {
                const firstFive: string = form.value['zipCode'].substring(0, 5);

                this.zipService.get(firstFive).subscribe(z => {
                    if (z != null) {
                        if (!!form.controls['city'] && !form.controls['city'].value) {
                            form.controls['city'].setValue(z.city);
                        }
                        if (!!form.controls['stateId'] && !form.controls['stateId'].value) {
                            form.controls['stateId'].setValue(this.vService.state(z.state).id);
                        }

                        if (!!form.controls['state'] && !form.controls['state'].value) {
                            form.controls['state'].setValue(this.vService.state(z.state).name);
                        }
                    }
                });
            }
        }
    }

    buildObject(form: any, obj: any, typeName: string = null) {
        let propertyAttributes: any = null;
        if (typeName !== null) {
            propertyAttributes = this.attributes[typeName];
        }
        for (const key of Object.keys(form)) {
            if (form[key] === '') {
                obj[key] = null;
            } else if (propertyAttributes != null) {
                const propAttributes = propertyAttributes.filter(prop => prop.key.toLowerCase() === key.toLowerCase());
                const uiHints: Array<UIHint> = propAttributes.filter(prop => prop.value.type === 'uiHint')
                    .map(prop => prop.value);

                if (uiHints.length === 1) {
                    const uiHint = uiHints[0];
                    const values = this.vService[uiHint.valuesFunction];
                    const controlsArray: FormArray = form[key];

                    obj[key] = values.filter(v => controlsArray[values.indexOf(v)] === true)
                        .map(v => {
                            const d = {};
                            d[uiHint.objectKey] = obj.id;
                            d[uiHint.childKey] = v.id;
                            return d;
                    });

                } else {
                    obj[key] = form[key];
                }
            } else {
                obj[key] = form[key];
            }
        }
    }

    buildArrayFromForm(form: any, array: any[], selectedValue: any, propertyName: string) {
        for (const key of Object.keys(form)) {
            if (form[key] === selectedValue) {
                const obj = {};
                obj[propertyName] = key;
                array.push(obj);
            }
        }
    }
}
