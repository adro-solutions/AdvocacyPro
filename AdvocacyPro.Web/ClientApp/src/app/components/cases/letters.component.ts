import { CaseChildListComponent } from './casechildlist.component';
import { Input, Component, OnInit } from '@angular/core';
import { CaseLetter } from 'src/app/models/caseLetter.model';
import { CasesService } from 'src/app/services/cases.service';
import { ValuesService } from 'src/app/services/values.service';
import { CSPNotificationService } from 'src/app/services/notification.service';
import { Router } from '@angular/router';
import { CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    selector: 'app-letters',
    template: './letters.component.html'
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
