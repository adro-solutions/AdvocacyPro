import { Component, ViewChild, Input, OnInit, Router, ActivatedRoute } from '../../vendor';
import { CasesService, FormService } from '../../services';
import { ModalComponent } from '../';
import { CasePolice, CaseAPIEndpoints, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

@Component({
    selector: 'police-case-modal',
    template: require('./policecase.component.html'),
    providers: [CasesService]
})
export class PoliceCaseComponent extends CaseChildComponent<CasePolice> implements OnInit {

    constructor(private _api: CasesService, private _formService: FormService,
    router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            super.initializeBase(+r["caseId"], ObjectType.CasePolice, new CasePolice(), CaseAPIEndpoints.Police);
            this.editItem(+r["id"]);

        });
    }
}
