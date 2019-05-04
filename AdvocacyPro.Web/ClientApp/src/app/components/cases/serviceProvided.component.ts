import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CaseService } from 'src/app/models/caseService.model';
import { ServiceCategory, ServiceProgram, ServicePopulation } from 'src/app/models/valueBase.model';
import { CasesService } from 'src/app/services/cases.service';
import { FormService } from 'src/app/services/form.service';
import { ValuesService } from 'src/app/services/values.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    template: require('./serviceProvided.component.html'),
})
export class ServiceProvidedComponent extends CaseChildComponent<CaseService> implements OnInit {
    caseServiceCategories: ServiceCategory[];
    caseServicePrograms: ServiceProgram[];
    filteredServicePrograms: ServiceProgram[];
    caseServicePopulations: ServicePopulation[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.caseServiceCategories = valueService.caseServiceCategories;
        this.caseServicePrograms = valueService.caseServicePrograms;
        this.caseServicePopulations = valueService.caseServicePopulations;
    }

    categoryChange() {
        this.formGroup.value['programId'] = null;
        this.filteredServicePrograms = this.caseServicePrograms.filter(csp => csp.categoryId === this.formGroup.value['categoryId']);
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            super.initializeBase(+r['caseId'], ObjectType.CaseService, new CaseService(), CaseAPIEndpoints.ServicesProvided);
            this.editItem(+r['id']);

        });
    }
}
