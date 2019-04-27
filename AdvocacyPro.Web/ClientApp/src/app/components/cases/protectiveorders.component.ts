import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CaseProtectiveOrder, CaseAPIEndpoints } from '../../models';
import { CaseChildListComponent } from './casechildlist.component';
import { ProtectiveOrderComponent } from '../';

@Component({
    selector: "protective-orders",
    template: require('./protectiveorders.component.html'),
    providers: [CasesService]
})
export class ProtectiveOrdersComponent extends CaseChildListComponent<CaseProtectiveOrder> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
    router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.ProtectiveOrders);
    }
}
