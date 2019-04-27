import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CaseEmergencyContact, CaseAPIEndpoints } from '../../models';
import { EmergencyContactComponent, CaseChildListComponent } from '../';

@Component({
    selector: "emergency-contacts",
    template: require('./emergencycontacts.component.html'),
    providers: [CasesService]
})
export class EmergencyContactsComponent extends CaseChildListComponent<CaseEmergencyContact> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
    router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.EmergencyContacts);
    }
}
