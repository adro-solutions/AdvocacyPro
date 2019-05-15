import { Component, OnInit, Input } from '@angular/core';
import { CaseChildListComponent } from './casechildlist.component';
import { CaseNote } from 'src/app/models/caseNote.model';
import { CasesService } from 'src/app/services/cases.service';
import { ValuesService } from 'src/app/services/values.service';
import { CSPNotificationService } from 'src/app/services/notification.service';
import { Router } from '@angular/router';
import { CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    selector: 'app-notes',
    template: './notes.component.html'
})
export class NotesComponent extends CaseChildListComponent<CaseNote> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService, router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.Notes);
    }
}
