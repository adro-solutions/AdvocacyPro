import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CaseWitness } from 'src/app/models/caseWitness.model';
import { RelationshipType, Gender, Race, Ethnicity } from 'src/app/models/valueBase.model';
import { CasesService } from 'src/app/services/cases.service';
import { FormService } from 'src/app/services/form.service';
import { ValuesService } from 'src/app/services/values.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    template: require('./witness.component.html'),
})
export class WitnessComponent extends CaseChildComponent<CaseWitness> implements OnInit {

    relationshipTypes: RelationshipType[];
    genders: Gender[];
    races: Race[];
    ethnicities: Ethnicity[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valuesService: ValuesService, router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.relationshipTypes = valuesService.relationshipTypes;
        this.genders = valuesService.genders;
        this.races = valuesService.races;
        this.ethnicities = valuesService.ethnicities;
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            super.initializeBase(+r['caseId'], ObjectType.CaseWitness, new CaseWitness(), CaseAPIEndpoints.Witnesses);
            this.editItem(+r['id']);

        });
    }
}
