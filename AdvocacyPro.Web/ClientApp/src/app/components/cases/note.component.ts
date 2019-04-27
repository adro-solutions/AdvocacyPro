import { Component, ViewChild, Input, OnInit, Router, ActivatedRoute } from '../../vendor';
import { CasesService, FormService } from '../../services';
import { ModalComponent } from '../';
import { CaseNote, CaseAPIEndpoints, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

@Component({
    selector: 'note-modal',
    template: require('./note.component.html'),
    providers: [CasesService]
})
export class NoteComponent extends CaseChildComponent<CaseNote> implements OnInit {
    constructor(private _api: CasesService, private _formService: FormService,
    router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            super.initializeBase(+r["caseId"], ObjectType.CaseNote, new CaseNote(), CaseAPIEndpoints.Notes);
            this.editItem(+r["id"]);

        });
    }
}
