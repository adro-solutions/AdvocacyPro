import { Component, OnInit, ViewEncapsulation, Observable } from '../../vendor';
import { CaseIncident } from '../../models';
import { ReportsService, ValuesService } from '../../services';
import { ReportBase } from '../';

@Component({
    template: require('./crimeStatistics.component.html'),
    styleUrls: ['print.css'],
    encapsulation: ViewEncapsulation.None,
    providers: [ReportsService]
})
export class CrimeStatisticsComponent extends ReportBase implements OnInit {
    output: [{ offenseId: number, count: number, group: [{ occurrenceDate: string, locationTypeId: number, count: number }] }];

    constructor(private api: ReportsService, private vService: ValuesService) {
        super();
    }

    ngOnInit() {
        this.reset();
    }
    
    search() {
        this.api.getCrimeData(this.dateStart, this.dateEnd).subscribe(i => {
            this.output = null;
            i.forEach(i => {
                if (!this.output) {
                    this.output = [{ offenseId: i.offenseId, count: 1, group: [{ occurrenceDate: i.occurrenceDate.toDateString(), count: 1, locationTypeId: i.locationTypeId }] }];
                }
                else {
                    var res = this.output.filter(f => f.offenseId == i.offenseId);
                    if (res.length > 0) {
                        res[0].count += 1;
                        var res2 = res[0].group.filter(g => g.locationTypeId == i.locationTypeId && g.occurrenceDate == i.occurrenceDate.toDateString());
                        if (res2.length > 0) {
                            res2[0].count += 1;
                        } else {
                            res[0].group.push({ occurrenceDate: i.occurrenceDate.toDateString(), count: 1, locationTypeId: i.locationTypeId });
                        }
                    } else {
                        this.output.push({ offenseId: i.offenseId, count: 1, group: [{ occurrenceDate: i.occurrenceDate.toDateString(), count: 1, locationTypeId: i.locationTypeId }] });
                    }
                }
            });
        });
    }
}