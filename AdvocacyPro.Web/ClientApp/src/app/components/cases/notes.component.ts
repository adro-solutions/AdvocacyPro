import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { CaseNote, CaseAPIEndpoints } from '../../models';
import { NoteComponent, CaseChildListComponent } from '../';

@Component({
    selector: "notes",
    template: require('./notes.component.html'),
    providers: [CasesService]
})
export class NotesComponent extends CaseChildListComponent<CaseNote> implements OnInit {
    @Input() caseId: number;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService, router: Router) {
        super(api, popupService, router);
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.Notes);
    }
}
