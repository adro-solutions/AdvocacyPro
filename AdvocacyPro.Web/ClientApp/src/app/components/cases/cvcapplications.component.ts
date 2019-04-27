import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CaseCVCApplication, CaseAPIEndpoints } from '../../models';
import { CVCApplicationComponent, CaseChildListComponent } from '../';

@Component({
    selector: "cvc-applications",
    template: require('./cvcapplications.component.html'),
    providers: [CasesService]
})
export class CVCApplicationsComponent extends CaseChildListComponent<CaseCVCApplication> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
    router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.CVCApplications);
    }
}
