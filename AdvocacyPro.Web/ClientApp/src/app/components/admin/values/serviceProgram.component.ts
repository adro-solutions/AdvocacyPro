import { ValueAPIEndpoints, ObjectType } from './../../../models/constants';
import { FormService } from './../../../services/form.service';
import { ValuesService } from './../../../services/values.service';
import { ServiceProgram, ServiceCategory } from './../../../models/valueBase.model';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    template: './serviceProgram.component.html'
})
export class ServiceProgramComponent implements OnInit {
    id: number;
    caseServiceProgram: ServiceProgram;
    caseServiceCategories: ServiceCategory[];
    formGroup: FormGroup;
    submitted = false;

    constructor(private api: ValuesService,
        private route: ActivatedRoute, private formService: FormService, private router: Router) {
        this.caseServiceCategories = api.caseServiceCategories;
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.id = +params['id'];

            if (this.id > 0) {
                this.api.get<ServiceProgram>(ValueAPIEndpoints.serviceprograms, this.id).subscribe(a => {
                    this.caseServiceProgram = a;
                    this.formService.buildFormGroup<ServiceProgram>(this.caseServiceProgram, ObjectType.ServiceProgram)
                        .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
                });
            } else {
                this.caseServiceProgram = new ServiceProgram();
                this.formService.buildFormGroup<ServiceProgram>(this.caseServiceProgram, ObjectType.ServiceProgram)
                    .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
            }
        });

    }

    submit(value: any) {
        this.submitted = true;
        if (this.formGroup.valid) {
            this.formService.buildObject(value, this.caseServiceProgram);
            if (this.id === 0) {
                this.api.create<ServiceProgram>(ValueAPIEndpoints.serviceprograms, this.caseServiceProgram)
                    .subscribe(() => this.router.navigate(['/admin/values/case-service-programs']));
            } else {
                this.api.update<ServiceProgram>(ValueAPIEndpoints.serviceprograms, this.id, this.caseServiceProgram).subscribe(() => {
                    this.router.navigate(['/admin/values/serviceprograms']);
                });
            }
        }
    }

}
