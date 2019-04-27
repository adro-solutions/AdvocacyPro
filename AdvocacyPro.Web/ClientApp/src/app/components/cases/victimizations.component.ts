import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CaseVictimization, CaseAPIEndpoints } from '../../models';
import { CaseChildListComponent } from './casechildlist.component';
import { VictimizationComponent } from '../';

@Component({
    selector: "victimizations",
    template: require('./victimizations.component.html'),
    providers: [CasesService]
})
export class VictimizationsComponent extends CaseChildListComponent<CaseVictimization> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService, router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.Victimizations);
    }
}
