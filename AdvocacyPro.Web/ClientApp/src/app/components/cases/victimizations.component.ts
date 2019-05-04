import { CaseChildListComponent } from './casechildlist.component';
import { Component, OnInit, Input } from '@angular/core';
import { CaseVictimization } from 'src/app/models/caseVictimization.model';
import { CasesService } from 'src/app/services/cases.service';
import { ValuesService } from 'src/app/services/values.service';
import { CSPNotificationService } from 'src/app/services/notification.service';
import { Router } from '@angular/router';
import { CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    selector: 'app-victimizations',
    template: require('./victimizations.component.html'),
})
export class VictimizationsComponent extends CaseChildListComponent<CaseVictimization> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService, router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.Victimizations);
    }
}
