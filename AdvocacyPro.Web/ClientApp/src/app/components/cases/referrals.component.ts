import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CaseReferral, CaseAPIEndpoints } from '../../models';
import { ReferralComponent, CaseChildListComponent } from '../';

@Component({
    selector: "referrals",
    template: require('./referrals.component.html'),
    providers: [CasesService]
})
export class ReferralsComponent extends CaseChildListComponent<CaseReferral> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
    router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.Referrals);
    }
}
