import { ValueTitles, ValueAPIEndpoints } from './../../../models/constants';
import { CSPNotificationService } from './../../../services/notification.service';
import { ValuesService } from './../../../services/values.service';
import { ValueBase } from './../../../models/valueBase.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    template: './valueList.component.html'
})
export class ValueListComponent implements OnInit {
    items: ValueBase[];
    type: string;
    title: string;

    constructor(private api: ValuesService, private popupService: CSPNotificationService, private route: ActivatedRoute) { }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.type = params['type'].toLowerCase();
            this.title = ValueTitles[this.type];
            this.api.getAll<ValueBase>(ValueAPIEndpoints[this.type]).subscribe(a => {
                this.items = a;
            });
        });
    }


    delete(id: number) {
        this.popupService.showConfirm('Delete?', 'Are you sure you want to delete this item?').subscribe(confirm => {
            if (confirm.response) {
                this.api.delete<ValueBase>(ValueAPIEndpoints[this.type], id).subscribe(() => {
                    const i = this.items.filter((status) => status.id === id)[0];
                    this.items.splice(this.items.indexOf(i), 1);
                });
            }
        });
    }
}
