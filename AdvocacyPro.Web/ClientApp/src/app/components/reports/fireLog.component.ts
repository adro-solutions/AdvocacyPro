import { Component, OnInit, ViewEncapsulation } from '../../vendor';
import { Fire } from '../../models';
import { ReportsService, ValuesService } from '../../services';
import { ReportBase } from '../';

@Component({
    template: require('./fireLog.component.html'),
    styleUrls: ['print.css'],
    encapsulation: ViewEncapsulation.None,
    providers: [ReportsService]
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