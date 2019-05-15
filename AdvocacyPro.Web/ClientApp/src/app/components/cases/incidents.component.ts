import { Component, OnInit, Input } from '@angular/core';
import { CasesService } from 'src/app/services/cases.service';
import { CaseChildListComponent } from './casechildlist.component';
import { CaseIncident } from 'src/app/models/caseIncident.model';
import { ValuesService } from 'src/app/services/values.service';
import { CSPNotificationService } from 'src/app/services/notification.service';
import { Router } from '@angular/router';
import { CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    selector: 'app-incidents',
    template: './incidents.component.html',
    providers: [CasesService]
})
export class IncidentsComponent extends CaseChildListComponent<CaseIncident> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
    router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.Incidents);
    }
}
