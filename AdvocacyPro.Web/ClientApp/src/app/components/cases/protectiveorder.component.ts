import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CasesService } from 'src/app/services/cases.service';
import { CaseProtectiveOrder } from 'src/app/models/caseProtectiveOrder.model';
import { OrderStatus, OrderType } from 'src/app/models/valueBase.model';
import { FormService } from 'src/app/services/form.service';
import { ValuesService } from 'src/app/services/values.service';
import { StateService } from 'src/app/services/state.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
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
            const newItem = new CaseProtectiveOrder();
            super.initializeBase(+r['caseId'], ObjectType.CaseProtectiveOrder, newItem, CaseAPIEndpoints.ProtectiveOrders);
            this.editItem(+r['id']);

        });
    }
}
