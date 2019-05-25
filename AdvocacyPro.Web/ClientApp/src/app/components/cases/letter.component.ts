import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CaseLetter } from 'src/app/models/caseLetter.model';
import { LetterType, Language } from 'src/app/models/valueBase.model';
import { CasesService } from 'src/app/services/cases.service';
import { FormService } from 'src/app/services/form.service';
import { ValuesService } from 'src/app/services/values.service';
import { StateService } from 'src/app/services/state.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    templateUrl: './letter.component.html'
})
export class LetterComponent extends CaseChildComponent<CaseLetter> implements OnInit {
    letterTypes: LetterType[];
    languages: Language[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, private stateService: StateService,
        router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.letterTypes = valueService.letterTypes;
        this.languages = valueService.languages;
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            const newItem = new CaseLetter();
            super.initializeBase(+r['caseId'], ObjectType.CaseLetter, newItem, CaseAPIEndpoints.Letters);
            this.editItem(+r['id']);
        });
    }
}
