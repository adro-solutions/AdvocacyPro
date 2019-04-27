import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CaseLetter, CaseAPIEndpoints } from '../../models';
import { CaseChildListComponent } from './casechildlist.component';
import { LetterComponent } from '../';

@Component({
    selector: "letters",
    template: require('./letters.component.html'),
    providers: [CasesService]
})
export class LettersComponent extends CaseChildListComponent<CaseLetter> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
        router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.Letters);
    }
}
