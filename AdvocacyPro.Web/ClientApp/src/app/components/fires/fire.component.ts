import { Component, OnInit, ActivatedRoute, FormGroup, Router } from '../../vendor';
import { Fire, UserData, Status, FireCause, LocationType } from '../../models';
import { FiresService, FormService, ValuesService, DashboardService, StateService, LocationsService } from '../../services';

@Component({
    selector: 'fire',
    template: require('./fire.component.html'),
    providers: [FiresService, LocationsService]
})
export class FireComponent implements OnInit {
    fire: Fire;
    id: number;
    tabIndex: number;
    formGroup: FormGroup;
    submitted: boolean;
    createdBy: string;
    updatedBy: string;
    archived: string;

    statuses: Status[];
    fireCauses: FireCause[];
    locationTypes: LocationType[];
    users: UserData[];
    locations: string[];
    oLocations: string[];

    constructor(private api: FiresService, private vService: ValuesService, private route: ActivatedRoute,
        private formService: FormService, private router: Router, private dService: DashboardService, private stateService: StateService,
        private locationsService: LocationsService) {
        this.statuses = vService.statuses;
        this.fireCauses = vService.fireCauses;
        this.locationTypes = vService.locationTypes;
        this.users = vService.users;
    }

    ngOnInit() {
        this.tabIndex = 0;

        this.locationsService.getAll().subscribe(d => this.oLocations = d);

        this.route.params.subscribe(params => {
            this.id = +params["id"];

            if (this.id > 0)
                this.api.get(this.id).subscribe(f => {
                    this.fire = f;
                    this.archived = f.archived ? 'y' : 'n';
                    this.buildForm();
                });
            else {
                this.archived = 'n';
                this.fire = new Fire();
                this.fire.staffUserId = this.stateService.user.id;
                this.buildForm();
            }
        });
    }

    search(event) {
        this.locations = this.oLocations.filter(l => l.toLowerCase().indexOf(event.query.toString().toLowerCase()) >= 0);
    }

    submit(value: any, saveAndClose: boolean) {
        this.submitted = true;
        if (this.formGroup.valid) {
            this.formService.buildObject(value, this.fire);
            if (this.id == 0)
                this.api.create(this.fire).subscribe(c => {
                    this.dService.refresh();
                    if (saveAndClose)
                        this.router.navigate(['/fires'], { queryParams: { 'archived': c.archived ? 'y' : 'n' } });
                    else {
                        this.fire = c;
                        this.id = c.id;
                        this.archived = c.archived ? 'y' : 'n';
                        this.buildForm();
                    }
                });
            else
                this.api.update(this.id, this.fire).subscribe(c => {
                    this.dService.refresh();
                    if (saveAndClose)
                        this.router.navigate(['/fires'], { queryParams: { 'archived': c.archived ? 'y' : 'n' } });
                    else {
                        this.fire = c;
                        this.archived = c.archived ? 'y' : 'n';
                        this.buildForm();
                    }
                });
        }
    }

    buildForm() {
        this.formService.buildFormGroup<Fire>(this.fire, "Fire")
            .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
    }
}
