import { Component, OnInit, ActivatedRoute, FormGroup, Router } from '../../vendor';
import { Case, UserData, Status, State, Gender, Race, Ethnicity } from '../../models';
import { CasesService, FormService, ValuesService, DashboardService, StateService } from '../../services';

@Component({
    selector: 'case',
    template: require('./case.component.html'),
    providers: [CasesService]
})
export class CaseComponent implements OnInit {
    case: Case;
    id: number;
    tab: string;
    formGroup: FormGroup;
    submitted: boolean;
    createdBy: string;
    updatedBy: string;
    archived: string;

    statuses: Status[];
    states: State[];
    genders: Gender[];
    races: Race[];
    ethnicities: Ethnicity[];
    users: UserData[];

    hasFeature: Function;

    constructor(private api: CasesService, private vService: ValuesService, private route: ActivatedRoute,
        private formService: FormService, private router: Router, private dService: DashboardService, private stateService: StateService) { 
        this.statuses = vService.statuses;
        this.states = vService.states;
        this.genders = vService.genders;
        this.races = vService.races;
        this.ethnicities = vService.ethnicities;
        this.users = vService.users;
        this.hasFeature = stateService.hasFeature;
    }

    ngOnInit() {
        this.tab = '';

        this.route.params.subscribe(params => {
            this.id = +params["caseId"];
            if (!!params["tab"])
                this.tab = params["tab"];
            else
                this.tab = '';

            if (this.id > 0)
                this.api.get(this.id).subscribe(c => {
                    this.case = c;
                    this.archived = c.archived ? 'y' : 'n';
                    this.buildForm();
                });
            else {
                this.archived = 'n';
                this.case = new Case();
                this.case.staffUserId = this.stateService.user.id;
                this.buildForm();
            }
        });
    }

    lookupZip() {
        this.formService.completeZip(this.formGroup);
    }

    submit(value: any, saveAndClose: boolean) {
        this.submitted = true;
        let formCase = new Case();
        if (this.formGroup.valid) {
            this.formService.buildObject(value, formCase);
            if (this.id == 0)
                this.api.create(formCase).subscribe(c => {
                    this.dService.refresh();
                    if (saveAndClose)
                        this.router.navigate(['/cases'], { queryParams: { 'archived': c.archived ? 'y' : 'n' } });
                    else {
                        this.case = c;
                        this.id = c.id;
                        this.archived = c.archived ? 'y' : 'n';
                        this.buildForm();
                    }
                });
            else
                this.api.update(this.id, formCase).subscribe(c => {
                    this.dService.refresh();
                    if (saveAndClose)
                        this.router.navigate(['/cases'], { queryParams: { 'archived': c.archived ? 'y' : 'n' } });
                    else {
                        this.case = c;
                        this.archived = c.archived ? 'y' : 'n';
                        this.buildForm();
                    }
                });
        }
    }

    buildForm() {
        this.formService.buildFormGroup<Case>(this.case, "Case")
            .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
    }
}
