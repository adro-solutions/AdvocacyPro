import { Component, OnInit, Input } from '@angular/core';
import { CaseChildListComponent } from './casechildlist.component';
import { CaseWitness } from 'src/app/models/caseWitness.model';
import { CasesService } from 'src/app/services/cases.service';
import { ValuesService } from 'src/app/services/values.service';
import { CSPNotificationService } from 'src/app/services/notification.service';
import { Router } from '@angular/router';
import { CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    selector: 'app-witnesses',
    template: './witnesses.component.html'
})
export class WitnessesComponent extends CaseChildListComponent<CaseWitness> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
    router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.Witnesses);
    }
}
