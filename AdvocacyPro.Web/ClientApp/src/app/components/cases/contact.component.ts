import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CasesService } from 'src/app/services/cases.service';
import { CaseContact } from 'src/app/models/caseContact.model';
import { ContactType } from 'src/app/models/valueBase.model';
import { FormService } from 'src/app/services/form.service';
import { ValuesService } from 'src/app/services/values.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    templateUrl: './contact.component.html',
})
export class ContactComponent extends CaseChildComponent<CaseContact> implements OnInit {
    caseContactTypes: ContactType[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.caseContactTypes = valueService.caseContactTypes;
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            super.initializeBase(+r['caseId'], ObjectType.CaseContact, new CaseContact(), CaseAPIEndpoints.ContactLog);
            this.editItem(+r['id']);
        });
    }
}
