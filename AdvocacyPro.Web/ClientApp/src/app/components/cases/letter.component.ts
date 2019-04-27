import { Component, ViewChild, Input, OnInit, ActivatedRoute, Router } from '../../vendor';
import { CasesService, FormService, ValuesService, StateService } from '../../services';
import { ModalComponent } from '../';
import { CaseLetter, LetterType, UserData, Language, CaseAPIEndpoints, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

@Component({
    selector: 'letter-modal',
    template: require('./letter.component.html'),
    providers: [CasesService]
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
            let newItem = new CaseLetter();
            super.initializeBase(+r["caseId"], ObjectType.CaseLetter, newItem, CaseAPIEndpoints.Letters);
            this.editItem(+r["id"]);

        });
    }
}
