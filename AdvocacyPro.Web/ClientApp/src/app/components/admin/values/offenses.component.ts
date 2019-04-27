import { Component, OnInit } from '../../../vendor';
import { ValuesService, CSPNotificationService } from '../../../services';
import { Offense, ValueAPIEndpoints } from '../../../models';

@Component({
    template: require('./offenses.component.html')
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
        this.popupService.showConfirm("Delete?", "Are you sure you want to delete this item?").subscribe(confirm => {
            if (confirm.response)
                this.api.delete<Offense>(ValueAPIEndpoints.offenses, id).subscribe(() => {
                    let i = this.offenses.filter((offense) => { return offense.id === id })[0];
                    this.offenses.splice(this.offenses.indexOf(i), 1);

                });
        });
    }
}
