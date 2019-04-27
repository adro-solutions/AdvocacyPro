import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CaseOffender, CaseAPIEndpoints } from '../../models';
import { OffenderComponent, CaseChildListComponent } from '../';

@Component({
    selector: "offenders",
    template: require('./offenders.component.html'),
    providers: [CasesService]
})
export class OffendersComponent extends CaseChildListComponent<CaseOffender> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
    router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.Offenders);
    }
}
