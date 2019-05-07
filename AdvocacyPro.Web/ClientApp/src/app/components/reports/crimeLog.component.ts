import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { ReportsService } from 'src/app/services/reports.service';
import { ReportBase } from './reportBase.component';
import { CaseIncident } from 'src/app/models/caseIncident.model';
import { ValuesService } from 'src/app/services/values.service';

@Component({
    template: require('./crimeLog.component.html'),
    styleUrls: ['print.css'],
    encapsulation: ViewEncapsulation.None,
})
export class CrimeLogComponent extends ReportBase implements OnInit {
    items: CaseIncident[];
    constructor(private api: ReportsService, private vService: ValuesService) {
        super();
    }

    ngOnInit() {
        this.reset();
    }

    search() {
        this.api.getCrimeData(this.dateStart, this.dateEnd).subscribe(i => this.items = i);
    }
}
