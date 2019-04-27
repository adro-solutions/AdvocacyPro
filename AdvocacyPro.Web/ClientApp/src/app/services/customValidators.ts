import { ValidatorFn, AbstractControl, Validators } from '@angular/forms';
import { CountryCode, isValidNumber, parse } from 'libphonenumber-js';

export class CustomValidators {
    private static isNullOrEmpty(obj: any): boolean {
        return obj === undefined || obj === null;
    }

    public static range = (minValue: number, maxValue: number): ValidatorFn => {
        return (control: AbstractControl): { [key: string]: any } => {
            if (CustomValidators.isNullOrEmpty(minValue)) { return null; }
            if (CustomValidators.isNullOrEmpty(maxValue)) { return null; }
            if (!CustomValidators.isNullOrEmpty(Validators.required(control))) { return null; }

            const val: number = +control.value;
            if (val >= minValue && val <= maxValue) { return null; }

            return { range: { minValue: minValue, maxValue: maxValue } };
        };
    }

    public static email: ValidatorFn = (control: AbstractControl): { [key: string]: boolean } => {
        if (!CustomValidators.isNullOrEmpty(Validators.required(control))) { return null; }

        const val: string = control.value;
        // tslint:disable-next-line:max-line-length
        const regex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

        return regex.test(val) ? null : { email: true };
    }

    public static phone = (countryCode: CountryCode): ValidatorFn => {
        return (control: AbstractControl): {
            [key: string]: boolean;
        } => {
            if (!CustomValidators.isNullOrEmpty(Validators.required(control))) {
                return null;
            }

            const val: string = control.value;
            return isValidNumber(parse(val, countryCode)) ? null : { phone: true };
        };
    }
}
