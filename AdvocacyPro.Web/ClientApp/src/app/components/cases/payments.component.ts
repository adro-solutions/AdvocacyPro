import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CasePayment, CaseAPIEndpoints } from '../../models';
import { CaseChildListComponent } from './casechildlist.component';
import { PaymentComponent } from '../';

@Component({
    selector: "payments",
    template: require('./payments.component.html'),
    providers: [CasesService]
})
export class PaymentsComponent extends CaseChildListComponent<CasePayment> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
    router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.Payments);
    }
}
