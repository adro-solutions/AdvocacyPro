import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { ReportBase } from './reportBase.component';
import { Fire } from 'src/app/models/fire.model';
import { ReportsService } from 'src/app/services/reports.service';
import { ValuesService } from 'src/app/services/values.service';

@Component({
    templateUrl: './fireLog.component.html',
    styleUrls: ['print.css'],
    encapsulation: ViewEncapsulation.None,
})
export class FireLogComponent extends ReportBase implements OnInit {
    items: Fire[];
    constructor(private api: ReportsService, private vService: ValuesService) {
        super();
    }

    ngOnInit() {
        this.reset();
    }

    search() {
        this.api.getFireData(this.dateStart, this.dateEnd).subscribe(i => this.items = i);
    }
}
