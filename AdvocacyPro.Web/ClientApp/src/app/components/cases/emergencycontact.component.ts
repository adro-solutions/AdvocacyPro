import { Component, ViewChild, Input, OnInit, Router, ActivatedRoute } from '../../vendor';
import { CasesService, FormService, ValuesService, StateService } from '../../services';
import { ModalComponent } from '../';
import { CaseEmergencyContact, State, Gender, Race, Ethnicity, CaseAPIEndpoints, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

@Component({
    selector: 'emergency-contact-modal',
    template: require('./emergencycontact.component.html'),
    providers: [CasesService]
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
            super.initializeBase(+r["caseId"], ObjectType.CaseEmergencyContact, new CaseEmergencyContact(), CaseAPIEndpoints.EmergencyContacts);
            this.editItem(+r["id"]);

        });
    }

    lookupZip() {
        this._formService.completeZip(this.formGroup);
    }
}
