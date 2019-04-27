import { Component, ViewChild, Input, OnInit, ActivatedRoute, Router } from '../../vendor';
import { CasesService, FormService, ValuesService, StateService } from '../../services';
import { ModalComponent } from '../';
import { CasePayment, PaymentCategory, UserData, Payor, CaseAPIEndpoints, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

@Component({
    selector: 'payment-modal',
    template: require('./payment.component.html'),
    providers: [CasesService]
})
export class PaymentComponent extends CaseChildComponent<CasePayment> implements OnInit {
    paymentCategories: PaymentCategory[];
    payors: Payor[];
    users: UserData[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, private stateService: StateService,
        router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.paymentCategories = valueService.paymentCategories;
        this.payors = valueService.payors;
        this.users = valueService.users;
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            let newItem = new CasePayment();
            super.initializeBase(+r["caseId"], ObjectType.CasePayment, newItem, CaseAPIEndpoints.Payments);
            this.editItem(+r["id"]);

        });
    }

}
