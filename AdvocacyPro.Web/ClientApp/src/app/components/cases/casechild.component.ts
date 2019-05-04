import { FormGroup } from '@angular/forms';
import { CasesService } from 'src/app/services/cases.service';
import { FormService } from 'src/app/services/form.service';
import { Router } from '@angular/router';

export class CaseChildComponent<T> {
    item: T;
    id: number;
    _caseId: number;
    formGroup: FormGroup;
    submitted = false;
    itemTypeName: string;
    private newItem: T;
    caseEndpoint: string;

    constructor(private api: CasesService, private formService: FormService, private router: Router) {
    }

    initializeBase(caseId: number, itemTypeName: string, newItem: T, caseEndpoint: string): void {
        this._caseId = caseId;
        this.itemTypeName = itemTypeName;
        this.newItem = newItem;
        this.caseEndpoint = caseEndpoint;

    }

    public editItem(id: number): void {
        this.id = id;
        if (id > 0) {
            this.api.getItem<T>(this._caseId, id, this.caseEndpoint).subscribe(
                result => {
                    this.item = result;
                    this.formService.buildFormGroup<T>(this.item, this.itemTypeName)
                        .subscribe((fbg: FormGroup) => {
                            this.formGroup = fbg;
                        });

                }
            );
        } else {
            this.item = this.newItem;
            this.formService.buildFormGroup<T>(this.item, this.itemTypeName)
                .subscribe((fbg: FormGroup) => {
                    this.formGroup = fbg;
                });
        }
    }

    submit(value: any) {
        this.submitted = true;
        if (this.formGroup.valid) {
            this.formService.buildObject(value, this.item, this.itemTypeName);
            if (this.id === 0) {
                this.api.createItem<T>(this._caseId, this.item, this.caseEndpoint).subscribe((item) => {
                    this.router.navigate([`/cases/${this._caseId}/${this.caseEndpoint}`]);
                });
            } else {
                this.api.updateItem<T>(this._caseId, this.id, this.item, this.caseEndpoint).subscribe((item) => {
                    this.router.navigate([`/cases/${this._caseId}/${this.caseEndpoint}`]);
                });
            }
        }
    }

    cancel(): void {
        this.router.navigate([`/cases/${this._caseId}/${this.caseEndpoint}`]);
    }
}
