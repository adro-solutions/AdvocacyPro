import { Component, ViewChild, Input, OnInit, Router, ActivatedRoute } from '../../vendor';
import { CasesService, FormService, ValuesService, StateService } from '../../services';
import { ModalComponent } from '../';
import { CaseCVCApplication, UserData, ApplicationStatus, OffenseType, ReferralType, CaseAPIEndpoints, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

@Component({
    selector: 'cvc-application-modal',
    template: require('./cvcapplication.component.html'),
    providers: [CasesService]
})
export class CVCApplicationComponent extends CaseChildComponent<CaseCVCApplication> implements OnInit {
    applicationStatuses: ApplicationStatus[];
    offenseTypes: OffenseType[];
    referralTypes: ReferralType[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, private stateService: StateService,
        router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.applicationStatuses = valueService.applicationStatuses;
        this.offenseTypes = valueService.offenseTypes;
        this.referralTypes = valueService.caseReferralTypes;
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            let newItem = new CaseCVCApplication();
            super.initializeBase(+r["caseId"], ObjectType.CaseCVCApplication, newItem, CaseAPIEndpoints.CVCApplications);
            this.editItem(+r["id"]);

        });
    }
}
