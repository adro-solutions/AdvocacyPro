import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CaseReferral } from 'src/app/models/caseReferral.model';
import { ReferralType } from 'src/app/models/valueBase.model';
import { CasesService } from 'src/app/services/cases.service';
import { FormService } from 'src/app/services/form.service';
import { ValuesService } from 'src/app/services/values.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    template: './referral.component.html'
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
            super.initializeBase(+r['caseId'], ObjectType.CaseReferral, new CaseReferral(), CaseAPIEndpoints.Referrals);
            this.editItem(+r['id']);

        });
    }
}
