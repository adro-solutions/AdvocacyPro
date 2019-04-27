import { Component, ViewChild, Input, OnInit, Router, ActivatedRoute } from '../../vendor';
import { CasesService, FormService, ValuesService } from '../../services';
import { ModalComponent } from '../';
import { CaseOffender, RelationshipType, State, Gender, Ethnicity, AgeGrouping, CaseAPIEndpoints, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

@Component({
    selector: 'offender-modal',
    template: require('./offender.component.html'),
    providers: [CasesService]
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
            super.initializeBase(+r["caseId"], ObjectType.CaseOffender, new CaseOffender(), CaseAPIEndpoints.Offenders);
            this.editItem(+r["id"]);

        });
    }

    lookupZip() {
        this._formService.completeZip(this.formGroup);
    }
}
