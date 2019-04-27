import { Component, ViewChild, Input, OnInit, Router, ActivatedRoute } from '../../vendor';
import { CasesService, FormService, ValuesService } from '../../services';
import { CaseContact, ContactType, CaseAPIEndpoints, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

@Component({
    selector: 'contact-modal',
    template: require('./contact.component.html'),
    providers: [CasesService]
})
export class ContactComponent extends CaseChildComponent<CaseContact> implements OnInit {
    caseContactTypes: ContactType[]
    
    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.caseContactTypes = valueService.caseContactTypes;
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            super.initializeBase(+r["caseId"], ObjectType.CaseContact, new CaseContact(), CaseAPIEndpoints.ContactLog);
            this.editItem(+r["id"]);

        });
    }
}
