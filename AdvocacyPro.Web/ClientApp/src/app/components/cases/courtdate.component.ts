import { Component, ViewChild, Input, OnInit, Router, ActivatedRoute } from '../../vendor';
import { CasesService, FormService, ValuesService, StateService } from '../../services';
import { ModalComponent } from '../';
import { CaseCourtDate, DocketType, UserData, BondType, CaseAPIEndpoints, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

@Component({
    selector: 'court-date-modal',
    template: require('./courtdate.component.html'),
    providers: [CasesService]
})
export class CourtDateComponent extends CaseChildComponent<CaseCourtDate> implements OnInit {
    docketTypes: DocketType[];
    bondTypes: BondType[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, private stateService: StateService,
        router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.docketTypes = valueService.docketTypes;
        this.bondTypes = valueService.bondTypes;
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            let newItem = new CaseCourtDate();
            super.initializeBase(+r["caseId"], ObjectType.CaseCourtDate, newItem, CaseAPIEndpoints.CourtDates);
            this.editItem(+r["id"]);

        });
    }
}
