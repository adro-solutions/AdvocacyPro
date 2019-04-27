import { Component, OnInit, ActivatedRoute, Router, FormGroup } from '../../../vendor';
import { ValuesService, FormService } from '../../../services';
import { Race, ValueAPIEndpoints } from '../../../models';

@Component({
    template: require('./race.component.html')
})
export class RaceComponent implements OnInit {
    id: number;
    race: Race;
    formGroup: FormGroup;
    submitted: boolean = false;

    constructor(private api: ValuesService, private route: ActivatedRoute, private formService: FormService, private router: Router) { }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.id = +params["id"];

            if (this.id > 0)
                this.api.get<Race>(ValueAPIEndpoints.races, this.id).subscribe(a => {
                    this.race = a;
                    this.formService.buildFormGroup<Race>(this.race, "Race")
                        .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
                });
            else {
                this.race = new Race();
                this.formService.buildFormGroup<Race>(this.race, "Race")
                    .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
            }
        });

    }

    submit(value: any) {
        this.submitted = true;
        if (this.formGroup.valid) {
            this.formService.buildObject(value, this.race);
            if (this.id == 0)
                this.api.create<Race>(ValueAPIEndpoints.races, this.race).subscribe(() => this.router.navigate(['/admin/values/races']));
            else
                this.api.update<Race>(ValueAPIEndpoints.races, this.id, this.race).subscribe(() => {
                    this.router.navigate(['/admin/values/races']);
                });
        }
    }

}
