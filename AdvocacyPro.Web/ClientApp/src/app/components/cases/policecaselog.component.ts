import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CasePolice, CaseAPIEndpoints } from '../../models';
import { PoliceCaseComponent, CaseChildListComponent } from '../';

@Component({
    selector: "police-case-log",
    template: require('./policecaselog.component.html'),
    providers: [CasesService]
})
export class PoliceCaseLogComponent extends CaseChildListComponent<CasePolice> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
    router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.Police);
    }
}
