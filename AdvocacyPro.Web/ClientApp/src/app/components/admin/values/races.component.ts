import { Component, OnInit } from '../../../vendor';
import { ValuesService, CSPNotificationService } from '../../../services';
import { Race, ValueAPIEndpoints } from '../../../models';

@Component({
    template: require('./races.component.html')
})
export class RacesComponent implements OnInit {
    races: Race[];

    constructor(private api: ValuesService, private popupService: CSPNotificationService) { }

    ngOnInit() {
        this.api.getAll<Race>(ValueAPIEndpoints.races).subscribe(a => {
            this.races = a;
        });
    }


    delete(id: number) {
        this.popupService.showConfirm("Delete?", "Are you sure you want to delete this item?").subscribe(confirm => {
            if (confirm.response)
                this.api.delete<Race>(ValueAPIEndpoints.races, id).subscribe(() => {
                    let i = this.races.filter((race) => { return race.id === id })[0];
                    this.races.splice(this.races.indexOf(i), 1);

                });
        });
    }
}