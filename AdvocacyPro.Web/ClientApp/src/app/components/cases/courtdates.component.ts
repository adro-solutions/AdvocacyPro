import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CaseCourtDate, CaseAPIEndpoints } from '../../models';
import { CourtDateComponent, CaseChildListComponent } from '../';

@Component({
    selector: "court-dates",
    template: require('./courtdates.component.html'),
    providers: [CasesService]
})
export class CourtDatesComponent extends CaseChildListComponent<CaseCourtDate> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService, router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.CourtDates);
    }
}
