import { Component, ViewChild, Input, OnInit, Router, ActivatedRoute } from '../../vendor';
import { CasesService, FormService, ValuesService } from '../../services';
import { ModalComponent } from '../';
import { CaseService, ServiceCategory, ServicePopulation, ServiceProgram, CaseAPIEndpoints, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

@Component({
    selector: 'service-provided-modal',
    template: require('./serviceProvided.component.html'),
    providers: [CasesService]
})
export class ServiceProvidedComponent extends CaseChildComponent<CaseService> implements OnInit {
    caseServiceCategories: ServiceCategory[];
    caseServicePrograms: ServiceProgram[];
    filteredServicePrograms: ServiceProgram[];
    caseServicePopulations: ServicePopulation[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.caseServiceCategories = valueService.caseServiceCategories;
        this.caseServicePrograms = valueService.caseServicePrograms;
        this.caseServicePopulations = valueService.caseServicePopulations;
    }

    categoryChange() {
        this.formGroup.value["programId"] = null;
        this.filteredServicePrograms = this.caseServicePrograms.filter(csp => csp.categoryId == this.formGroup.value["categoryId"]);
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            super.initializeBase(+r["caseId"], ObjectType.CaseService, new CaseService(), CaseAPIEndpoints.ServicesProvided);
            this.editItem(+r["id"]);

        });
    }
}
