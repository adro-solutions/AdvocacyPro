import { Component, ViewChild, Input, OnInit, Router, ActivatedRoute } from '../../vendor';
import { CasesService, FormService, ValuesService, StateService } from '../../services';
import { ModalComponent } from '../';
import { CaseProtectiveOrder, OrderStatus, UserData, OrderType, CaseAPIEndpoints, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

@Component({
    selector: 'protective-order-modal',
    template: require('./protectiveorder.component.html'),
    providers: [CasesService]
})
export class ProtectiveOrderComponent extends CaseChildComponent<CaseProtectiveOrder> implements OnInit {
    orderStatuses: OrderStatus[];
    orderTypes: OrderType[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, private stateService: StateService,
        router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.orderStatuses = valueService.orderStatuses;
        this.orderTypes = valueService.orderTypes;
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            let newItem = new CaseProtectiveOrder();
            super.initializeBase(+r["caseId"], ObjectType.CaseProtectiveOrder, newItem, CaseAPIEndpoints.ProtectiveOrders);
            this.editItem(+r["id"]);

        });
    }
}
