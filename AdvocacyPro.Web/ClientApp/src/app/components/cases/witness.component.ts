import { Component, ViewChild, Input, OnInit, ActivatedRoute, Router } from '../../vendor';
import { CasesService, FormService, ValuesService } from '../../services';
import { ModalComponent } from '../';
import { CaseWitness, RelationshipType, Gender, Race, Ethnicity, CaseAPIEndpoints, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

@Component({
    selector: 'witness-modal',
    template: require('./witness.component.html'),
    providers: [CasesService]
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
            super.initializeBase(+r["caseId"], ObjectType.CaseWitness, new CaseWitness(), CaseAPIEndpoints.Witnesses);
            this.editItem(+r["id"]);

        });
    }
}
