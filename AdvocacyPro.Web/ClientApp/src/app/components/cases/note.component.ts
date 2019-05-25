import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CaseNote } from 'src/app/models/caseNote.model';
import { CasesService } from 'src/app/services/cases.service';
import { FormService } from 'src/app/services/form.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    templateUrl: './note.component.html'
})
export class NoteComponent extends CaseChildComponent<CaseNote> implements OnInit {
    constructor(private _api: CasesService, private _formService: FormService,
    router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            super.initializeBase(+r['caseId'], ObjectType.CaseNote, new CaseNote(), CaseAPIEndpoints.Notes);
            this.editItem(+r['id']);

        });
    }
}
