import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CaseContact, CaseAPIEndpoints } from '../../models';
import { ContactComponent, CaseChildListComponent } from '../';

@Component({
    selector: "contact-log",
    template: require('./contactlog.component.html'),
    providers: [CasesService]
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
