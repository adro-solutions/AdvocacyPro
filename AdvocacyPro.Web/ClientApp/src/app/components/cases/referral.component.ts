import { Component, ViewChild, Input, OnInit, Router, ActivatedRoute } from '../../vendor';
import { CasesService, FormService, ValuesService, StateService } from '../../services';
import { ModalComponent } from '../';
import { CaseReferral, ReferralType, CaseAPIEndpoints, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

@Component({
    selector: 'referral-modal',
    template: require('./referral.component.html'),
    providers: [CasesService]
})
export class ReferralComponent extends CaseChildComponent<CaseReferral> implements OnInit {
    caseReferralTypes: ReferralType[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.caseReferralTypes = valueService.caseReferralTypes;
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            super.initializeBase(+r["caseId"], ObjectType.CaseReferral, new CaseReferral(), CaseAPIEndpoints.Referrals);
            this.editItem(+r["id"]);

        });
    }
}
