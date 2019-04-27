import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CaseIncident, CaseAPIEndpoints } from '../../models';
import { IncidentComponent, CaseChildListComponent } from '../';

@Component({
    selector: "incidents",
    template: require('./incidents.component.html'),
    providers: [CasesService]
})
export class IncidentsComponent extends CaseChildListComponent<CaseIncident> implements OnInit {
    @Input() caseId: number;
    
    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
    router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.Incidents);
    }
}
