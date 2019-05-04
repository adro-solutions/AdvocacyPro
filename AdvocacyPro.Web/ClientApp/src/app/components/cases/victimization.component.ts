import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CaseVictimization } from 'src/app/models/caseVictimization.model';
import { VictimType } from 'src/app/models/valueBase.model';
import { CasesService } from 'src/app/services/cases.service';
import { FormService } from 'src/app/services/form.service';
import { ValuesService } from 'src/app/services/values.service';
import { StateService } from 'src/app/services/state.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    template: require('./victimization.component.html'),
})
export class VictimizationComponent extends CaseChildComponent<CaseVictimization> implements OnInit {
    victimTypes: VictimType[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, private stateService: StateService,
        router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.victimTypes = valueService.victimTypes;
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            const newItem = new CaseVictimization();
            super.initializeBase(+r['caseId'], ObjectType.CaseVictimization, newItem, CaseAPIEndpoints.Victimizations);
            this.editItem(+r['id']);

        });
    }
}
