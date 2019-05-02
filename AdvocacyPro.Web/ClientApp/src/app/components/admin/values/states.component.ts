import { ValueAPIEndpoints } from './../../../models/constants';
import { CSPNotificationService } from './../../../services/notification.service';
import { ValuesService } from './../../../services/values.service';
import { State } from './../../../models/valueBase.model';
import { Component, OnInit } from '@angular/core';

@Component({
    template: require('./states.component.html')
})
export class StatesComponent implements OnInit {
    states: State[];

    constructor(private api: ValuesService, private popupService: CSPNotificationService) { }

    ngOnInit() {
        this.api.getAll<State>(ValueAPIEndpoints.states).subscribe(a => {
            this.states = a;
        });
    }


    delete(id: number) {
        this.popupService.showConfirm('Delete?', 'Are you sure you want to delete this item?').subscribe(confirm => {
            if (confirm.response) {
                this.api.delete<State>(ValueAPIEndpoints.states, id).subscribe(() => {
                    const i = this.states.filter((state) => state.id === id)[0];
                    this.states.splice(this.states.indexOf(i), 1);
                });
            }
        });
    }
}
