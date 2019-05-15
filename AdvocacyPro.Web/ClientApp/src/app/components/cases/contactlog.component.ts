import { Component, OnInit, Input } from '@angular/core';
import { CaseChildListComponent } from './casechildlist.component';
import { CaseContact } from 'src/app/models/caseContact.model';
import { CasesService } from 'src/app/services/cases.service';
import { ValuesService } from 'src/app/services/values.service';
import { CSPNotificationService } from 'src/app/services/notification.service';
import { Router } from '@angular/router';
import { CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    selector: 'app-contact-log',
    template: './contactlog.component.html',
})
export class ContactLogComponent extends CaseChildListComponent<CaseContact> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
        router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.ContactLog);
    }
}
