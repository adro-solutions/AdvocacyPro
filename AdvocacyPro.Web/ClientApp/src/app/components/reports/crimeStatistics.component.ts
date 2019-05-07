import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { ReportsService } from 'src/app/services/reports.service';
import { ReportBase } from './reportBase.component';
import { ValuesService } from 'src/app/services/values.service';

@Component({
    template: require('./crimeStatistics.component.html'),
    styleUrls: ['print.css'],
    encapsulation: ViewEncapsulation.None,
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
            i.forEach(i2 => {
                if (!this.output) {
                    this.output = [{
                        offenseId: i2.offenseId,
                        count: 1,
                        group: [{ occurrenceDate: i2.occurrenceDate.toDateString(), count: 1, locationTypeId: i2.locationTypeId }] }];
                } else {
                    const res = this.output.filter(f => f.offenseId === i2.offenseId);
                    if (res.length > 0) {
                        res[0].count += 1;
                        const res2 = res[0].group.filter(g => g.locationTypeId === i2.locationTypeId
                            && g.occurrenceDate === i2.occurrenceDate.toDateString());
                        if (res2.length > 0) {
                            res2[0].count += 1;
                        } else {
                            res[0].group.push({
                                occurrenceDate: i2.occurrenceDate.toDateString(),
                                count: 1,
                                locationTypeId: i2.locationTypeId });
                        }
                    } else {
                        this.output.push({
                            offenseId: i2.offenseId,
                            count: 1,
                            group: [{ occurrenceDate: i2.occurrenceDate.toDateString(), count: 1, locationTypeId: i2.locationTypeId }] });
                    }
                }
            });
        });
    }
}
