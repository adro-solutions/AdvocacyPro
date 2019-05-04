import { Component, OnInit, Input } from '@angular/core';
import { CasesService } from 'src/app/services/cases.service';
import { CaseChildListComponent } from './casechildlist.component';
import { CaseCVCApplication } from 'src/app/models/caseCVCApplication.model';
import { ValuesService } from 'src/app/services/values.service';
import { CSPNotificationService } from 'src/app/services/notification.service';
import { Router } from '@angular/router';
import { CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    selector: 'app-cvc-applications',
    template: require('./cvcapplications.component.html'),
})
export class CVCApplicationsComponent extends CaseChildListComponent<CaseCVCApplication> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
    router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.CVCApplications);
    }
}
