﻿import { Component, ViewChild, Input, OnInit, Router, ActivatedRoute } from '../../vendor';
import { CasesService, FormService, ValuesService, StateService } from '../../services';
import { ModalComponent } from '../';
import { CaseVictimization, VictimType, UserData, CaseAPIEndpoints, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

@Component({
    selector: 'victimization-modal',
    template: require('./victimization.component.html'),
    providers: [CasesService]
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
            let newItem = new CaseVictimization();
            super.initializeBase(+r["caseId"], ObjectType.CaseVictimization, newItem, CaseAPIEndpoints.Victimizations);
            this.editItem(+r["id"]);

        });
    }
}
