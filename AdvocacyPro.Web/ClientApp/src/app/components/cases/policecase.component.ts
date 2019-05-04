import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CasePolice } from 'src/app/models/casePolice.model';
import { CasesService } from 'src/app/services/cases.service';
import { FormService } from 'src/app/services/form.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    template: require('./policecase.component.html'),
})
export class PoliceCaseComponent extends CaseChildComponent<CasePolice> implements OnInit {

    constructor(private _api: CasesService, private _formService: FormService,
    router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            super.initializeBase(+r['caseId'], ObjectType.CasePolice, new CasePolice(), CaseAPIEndpoints.Police);
            this.editItem(+r['id']);

        });
    }
}
