import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CaseWitness, CaseAPIEndpoints } from '../../models';
import { WitnessComponent, CaseChildListComponent } from '../';

@Component({
    selector: "witnesses",
    template: require('./witnesses.component.html'),
    providers: [CasesService]
})
export class WitnessesComponent extends CaseChildListComponent<CaseWitness> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
    router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.Witnesses);
    }
}
