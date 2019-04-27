import { Component, OnInit, FormGroup, FormBuilder, Validators, Observable, ActivatedRoute } from '../../vendor';
import { FiresService, ValuesService, CSPNotificationService } from '../../services';
import { Fire, FireCause, LocationType } from '../../models';

@Component({
    selector: 'fires',
    template: require('./fires.component.html'),
    providers: [FiresService]
})
export class FiresComponent implements OnInit {
    fires: Fire[];
    filteredFires: Fire[];
    formGroup: FormGroup;
    archived: boolean;

    locationTypes: LocationType[];
    fireCauses: FireCause[];

    constructor(private api: FiresService, private vService: ValuesService, private fb: FormBuilder,
        private popupService: CSPNotificationService, private route: ActivatedRoute) {
        this.locationTypes = vService.locationTypes;
        this.fireCauses = vService.fireCauses;
    }

    ngOnInit() {
        this.route.queryParams.subscribe(p => {
            this.archived = p["archived"] == "y";
            this.api.getAll(this.archived).subscribe(f => {
                this.fires = f;
                this.reset();
            });
        });

    }

    reset() {
        this.formGroup = this.fb.group({
            location: '',
            occurrenceDateStart: null,
            occurrenceDateEnd: null,
            locationTypeId: null,
            causeId: null
        });
        this.search(this.formGroup.value);
    }

    archive(f: Fire) {
        this.popupService.showConfirm("Archive?", "Are you sure you want to archive this item?").subscribe(confirm => {
            if (confirm.response) {
                f.archived = true;
                this.api.update(f.id, f).subscribe(() => {
                    let i = this.fires.filter((fire) => { return fire.id === f.id })[0];
                    this.fires.splice(this.fires.indexOf(i), 1);
                    this.search(this.formGroup.value);
                });
            }
        });
    }

    search(formValue) {
        this.filteredFires = this.fires.filter(f => {
            if (f.location.toLowerCase().indexOf(formValue["location"].toLowerCase()) < 0)
                return false;

            if (formValue["occurrenceDateStart"] != null && new Date(formValue["occurrenceDateStart"]) > new Date(f.occurrenceDate))
                return false;

            if (formValue["occurrenceDateEnd"] != null && new Date(formValue["occurrenceDateEnd"]) < new Date(f.occurrenceDate))
                return false;

            if (formValue["locationTypeId"] != null && formValue["locationTypeId"] != f.locationTypeId)
                return false;

            if (formValue["causeId"] != null && formValue["causeId"] != f.causeId)
                return false;

            return true;
        });
    }
}
