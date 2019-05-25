import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CaseEmergencyContact } from 'src/app/models/caseEmergencyContact.model';
import { State, Gender, Race, Ethnicity } from 'src/app/models/valueBase.model';
import { CasesService } from 'src/app/services/cases.service';
import { FormService } from 'src/app/services/form.service';
import { ValuesService } from 'src/app/services/values.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    templateUrl: './emergencycontact.component.html',
})
export class EmergencyContactComponent extends CaseChildComponent<CaseEmergencyContact> implements OnInit  {
    states: State[];
    genders: Gender[];
    races: Race[];
    ethnicities: Ethnicity[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.states = valueService.states;
        this.genders = valueService.genders;
        this.races = valueService.races;
        this.ethnicities = valueService.ethnicities;
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            super.initializeBase(+r['caseId'], ObjectType.CaseEmergencyContact,
                new CaseEmergencyContact(), CaseAPIEndpoints.EmergencyContacts);
            this.editItem(+r['id']);
        });
    }

    lookupZip() {
        this._formService.completeZip(this.formGroup);
    }
}
