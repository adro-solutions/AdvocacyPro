import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CaseCVCApplication } from 'src/app/models/caseCVCApplication.model';
import { ApplicationStatus, OffenseType, ReferralType } from 'src/app/models/valueBase.model';
import { CasesService } from 'src/app/services/cases.service';
import { FormService } from 'src/app/services/form.service';
import { ValuesService } from 'src/app/services/values.service';
import { StateService } from 'src/app/services/state.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    templateUrl: './cvcapplication.component.html',
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
            const newItem = new CaseCVCApplication();
            super.initializeBase(+r['caseId'], ObjectType.CaseCVCApplication, newItem, CaseAPIEndpoints.CVCApplications);
            this.editItem(+r['id']);

        });
    }
}
