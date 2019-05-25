import { ValueTitles, ValueAPIEndpoints } from './../../../models/constants';
import { FormService } from './../../../services/form.service';
import { ValuesService } from './../../../services/values.service';
import { ValueBase } from './../../../models/valueBase.model';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    templateUrl: './value.component.html'
})
export class ValueComponent implements OnInit {
    id: number;
    type: string;
    title: string;
    item: ValueBase;
    formGroup: FormGroup;
    submitted = false;

    constructor(private api: ValuesService, private route: ActivatedRoute, private formService: FormService, private router: Router) { }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.id = +params['id'];
            this.type = params['type'].toLowerCase();
            this.title = ValueTitles[this.type];

            if (this.id > 0) {
                this.api.get<ValueBase>(ValueAPIEndpoints[this.type], this.id).subscribe(a => {
                    this.item = a;
                    this.formService.buildFormGroup<ValueBase>(this.item, 'ValueBase')
                        .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
                });
            } else {
                this.item = new ValueBase();
                this.formService.buildFormGroup<ValueBase>(this.item, 'ValueBase')
                    .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
            }
        });

    }

    submit(value: any) {
        this.submitted = true;
        if (this.formGroup.valid) {
            this.formService.buildObject(value, this.item);
            if (this.id === 0) {
                this.api.create<ValueBase>(ValueAPIEndpoints[this.type], this.item)
                    .subscribe(() => this.router.navigate([`/admin/values/${this.type}`]));
            } else {
                this.api.update<ValueBase>(ValueAPIEndpoints[this.type], this.id, this.item).subscribe(() => {
                    this.router.navigate([`/admin/values/${this.type}`]);
                });
            }
        }
    }

}
