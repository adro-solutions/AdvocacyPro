import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CaseOffender } from 'src/app/models/caseOffender.model';
import { RelationshipType, State, Gender, Ethnicity, AgeGrouping } from 'src/app/models/valueBase.model';
import { CasesService } from 'src/app/services/cases.service';
import { FormService } from 'src/app/services/form.service';
import { ValuesService } from 'src/app/services/values.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    template: require('./offender.component.html'),
})
export class OffenderComponent extends CaseChildComponent<CaseOffender> implements OnInit {
    relationshipTypes: RelationshipType[];
    states: State[];
    genders: Gender[];
    ethnicities: Ethnicity[];
    ageGroupings: AgeGrouping[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.relationshipTypes = valueService.relationshipTypes;
        this.states = valueService.states;
        this.genders = valueService.genders;
        this.ethnicities = valueService.ethnicities;
        this.ageGroupings = valueService.ageGroupings;
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            super.initializeBase(+r['caseId'], ObjectType.CaseOffender, new CaseOffender(), CaseAPIEndpoints.Offenders);
            this.editItem(+r['id']);

        });
    }

    lookupZip() {
        this._formService.completeZip(this.formGroup);
    }
}
