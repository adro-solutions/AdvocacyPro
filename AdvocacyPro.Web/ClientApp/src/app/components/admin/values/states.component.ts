import { Component, OnInit } from '../../../vendor';
import { ValuesService, CSPNotificationService } from '../../../services';
import { State, ValueAPIEndpoints } from '../../../models';

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
        this.popupService.showConfirm("Delete?", "Are you sure you want to delete this item?").subscribe(confirm => {
            if (confirm.response)
                this.api.delete<State>(ValueAPIEndpoints.states, id).subscribe(() => {
                    let i = this.states.filter((state) => { return state.id === id })[0];
                    this.states.splice(this.states.indexOf(i), 1);

                });
        });
    }
}