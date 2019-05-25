import { ValueAPIEndpoints } from './../../../models/constants';
import { CSPNotificationService } from './../../../services/notification.service';
import { ValuesService } from './../../../services/values.service';
import { Race } from './../../../models/valueBase.model';
import { Component, OnInit } from '@angular/core';

@Component({
    templateUrl: './races.component.html'
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
        this.popupService.showConfirm('Delete?', 'Are you sure you want to delete this item?').subscribe(confirm => {
            if (confirm.response) {
                this.api.delete<Race>(ValueAPIEndpoints.races, id).subscribe(() => {
                    const i = this.races.filter((race) => race.id === id)[0];
                    this.races.splice(this.races.indexOf(i), 1);
                });
            }
        });
    }
}
