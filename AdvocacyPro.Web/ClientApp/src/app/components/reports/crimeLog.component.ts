import { Component, OnInit, ViewEncapsulation } from '../../vendor';
import { CaseIncident } from '../../models';
import { ReportsService, ValuesService } from '../../services';
import { ReportBase } from '../';

@Component({
    template: require('./crimeLog.component.html'),
    styleUrls: ['print.css'],
    encapsulation: ViewEncapsulation.None,
    providers: [ReportsService]
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