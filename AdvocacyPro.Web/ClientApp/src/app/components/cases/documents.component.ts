import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CaseDocument, CaseAPIEndpoints } from '../../models';
import { DocumentComponent, CaseChildListComponent } from '../';

@Component({
    selector: "documents",
    template: require('./documents.component.html'),
    providers: [CasesService]
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
