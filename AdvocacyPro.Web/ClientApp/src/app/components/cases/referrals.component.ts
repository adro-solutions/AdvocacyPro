import { Component, OnInit, Input } from '@angular/core';
import { CasesService } from 'src/app/services/cases.service';
import { CaseChildListComponent } from './casechildlist.component';
import { CaseReferral } from 'src/app/models/caseReferral.model';
import { ValuesService } from 'src/app/services/values.service';
import { CSPNotificationService } from 'src/app/services/notification.service';
import { Router } from '@angular/router';
import { CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    selector: 'app-referrals',
    template: './referrals.component.html'
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
