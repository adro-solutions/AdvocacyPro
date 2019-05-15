import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CaseCourtDate } from 'src/app/models/caseCourtDate.model';
import { DocketType, BondType } from 'src/app/models/valueBase.model';
import { CasesService } from 'src/app/services/cases.service';
import { FormService } from 'src/app/services/form.service';
import { ValuesService } from 'src/app/services/values.service';
import { StateService } from 'src/app/services/state.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    template: './courtdate.component.html',
})
export class CourtDateComponent extends CaseChildComponent<CaseCourtDate> implements OnInit {
    docketTypes: DocketType[];
    bondTypes: BondType[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, private stateService: StateService,
        router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.docketTypes = valueService.docketTypes;
        this.bondTypes = valueService.bondTypes;
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            const newItem = new CaseCourtDate();
            super.initializeBase(+r['caseId'], ObjectType.CaseCourtDate, newItem, CaseAPIEndpoints.CourtDates);
            this.editItem(+r['id']);

        });
    }
}
