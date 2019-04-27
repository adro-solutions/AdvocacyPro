import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CaseService, CaseAPIEndpoints } from '../../models';
import { ServiceProvidedComponent, CaseChildListComponent } from '../';

@Component({
    selector: "services-provided",
    template: require('./servicesProvided.component.html'),
    providers: [CasesService]
})
export class ServicesProvidedComponent extends CaseChildListComponent<CaseService> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
    router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.ServicesProvided);
    }
}
