import { ValueAPIEndpoints } from './../../../models/constants';
import { CSPNotificationService } from './../../../services/notification.service';
import { ValuesService } from './../../../services/values.service';
import { Offense } from './../../../models/valueBase.model';
import { Component, OnInit } from '@angular/core';

@Component({
    templateUrl: './offenses.component.html'
})
export class OffensesComponent implements OnInit {
    offenses: Offense[];

    constructor(private api: ValuesService, private popupService: CSPNotificationService) { }

    ngOnInit() {
        this.api.getAll<Offense>(ValueAPIEndpoints.offenses).subscribe(a => {
            this.offenses = a;
        });
    }


    delete(id: number) {
        this.popupService.showConfirm('Delete?', 'Are you sure you want to delete this item?').subscribe(confirm => {
            if (confirm.response) {
                this.api.delete<Offense>(ValueAPIEndpoints.offenses, id).subscribe(() => {
                    const i = this.offenses.filter((offense) => offense.id === id)[0];
                    this.offenses.splice(this.offenses.indexOf(i), 1);
                });
            }
        });
    }
}
