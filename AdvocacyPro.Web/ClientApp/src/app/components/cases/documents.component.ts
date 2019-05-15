import { Component, OnInit, Input } from '@angular/core';
import { CaseChildListComponent } from './casechildlist.component';
import { CaseDocument } from 'src/app/models/caseDocument.model';
import { CasesService } from 'src/app/services/cases.service';
import { ValuesService } from 'src/app/services/values.service';
import { CSPNotificationService } from 'src/app/services/notification.service';
import { Router } from '@angular/router';
import { CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    selector: 'app-documents',
    template: './documents.component.html',
})
export class DocumentsComponent extends CaseChildListComponent<CaseDocument> implements OnInit {
    @Input() caseId: number;

    constructor(private caseApi: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
    router: Router) {
        super(caseApi, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.Documents);
    }

    download(id: number, fileName: string) {
        this.caseApi.downloadDocument(this.caseId, id, fileName);
    }
}
