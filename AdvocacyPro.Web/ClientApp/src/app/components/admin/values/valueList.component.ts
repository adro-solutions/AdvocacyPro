import { ActivatedRoute, Component, OnInit } from '../../../vendor';
import { ValuesService, CSPNotificationService } from '../../../services';
import { ValueBase, ValueAPIEndpoints, ValueTitles } from '../../../models';

@Component({
    template: require('./valueList.component.html')
})
export class ValueListComponent implements OnInit {
    items: ValueBase[];
    type: string;
    title: string;

    constructor(private api: ValuesService, private popupService: CSPNotificationService, private route: ActivatedRoute) { }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.type = params["type"].toLowerCase();
            this.title = ValueTitles[this.type];
            this.api.getAll<ValueBase>(ValueAPIEndpoints[this.type]).subscribe(a => {
                this.items = a;
            });
        });
    }


    delete(id: number) {
        this.popupService.showConfirm("Delete?", "Are you sure you want to delete this item?").subscribe(confirm => {
            if (confirm.response)
                this.api.delete<ValueBase>(ValueAPIEndpoints[this.type], id).subscribe(() => {
                    let i = this.items.filter((status) => { return status.id === id })[0];
                    this.items.splice(this.items.indexOf(i), 1);
                });
        });
    }
}
