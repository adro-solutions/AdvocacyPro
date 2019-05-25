import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CasePayment } from 'src/app/models/casePayment.model';
import { PaymentCategory, Payor } from 'src/app/models/valueBase.model';
import { UserData } from 'src/app/models/userData.model';
import { CasesService } from 'src/app/services/cases.service';
import { FormService } from 'src/app/services/form.service';
import { ValuesService } from 'src/app/services/values.service';
import { StateService } from 'src/app/services/state.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    templateUrl: './payment.component.html'
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
            const newItem = new CasePayment();
            super.initializeBase(+r['caseId'], ObjectType.CasePayment, newItem, CaseAPIEndpoints.Payments);
            this.editItem(+r['id']);

        });
    }

}
