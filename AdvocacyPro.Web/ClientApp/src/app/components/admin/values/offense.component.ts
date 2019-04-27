import { Component, OnInit, ActivatedRoute, Router, FormGroup } from '../../../vendor';
import { ValuesService, FormService } from '../../../services';
import { Offense, OffenseType, ValueAPIEndpoints } from '../../../models';

@Component({
    template: require('./offense.component.html')
})
export class OffenseComponent implements OnInit {
    id: number;
    offense: Offense;
    offenseTypes: OffenseType[];
    formGroup: FormGroup;
    submitted: boolean = false;

    constructor(private api: ValuesService, private route: ActivatedRoute, private formService: FormService, private router: Router) {
        this.offenseTypes = api.offenseTypes;
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.id = +params["id"];

            if (this.id > 0)
                this.api.get<Offense>(ValueAPIEndpoints.offenses, this.id).subscribe(a => {
                    this.offense = a;
                    this.formService.buildFormGroup<Offense>(this.offense, "Offense")
                        .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
                });
            else {
                this.offense = new Offense();
                this.formService.buildFormGroup<Offense>(this.offense, "Offense")
                    .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
            }
        });

    }

    submit(value: any) {
        this.submitted = true;
        if (this.formGroup.valid) {
            this.formService.buildObject(value, this.offense);
            if (this.id == 0)
                this.api.create<Offense>(ValueAPIEndpoints.offenses, this.offense).subscribe(() => this.router.navigate(['/admin/values/offenses']));
            else
                this.api.update<Offense>(ValueAPIEndpoints.offenses, this.id, this.offense).subscribe(() => {
                    this.router.navigate(['/admin/values/offenses']);
                });
        }
    }

}
