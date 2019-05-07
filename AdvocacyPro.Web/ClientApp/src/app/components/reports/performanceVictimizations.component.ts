import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { ReportBase } from './reportBase.component';
import { VictimType } from 'src/app/models/valueBase.model';
import { ReportsService } from 'src/app/services/reports.service';
import { ValuesService } from 'src/app/services/values.service';

@Component({
    template: require('./performanceVictimizations.component.html'),
    styleUrls: ['print.css'],
    encapsulation: ViewEncapsulation.None,
})
export class PerformanceVictimizationsComponent extends ReportBase implements OnInit {
    victimTypes: VictimType[];
    output: [{ typeId: number, count: number }];

    constructor(private api: ReportsService, private vService: ValuesService) {
        super();
        this.victimTypes = vService.victimTypes;

    }

    ngOnInit() {
        this.reset();
    }

    getVictimTypeCount(typeId: number): number {
        return this.output.filter(o => o.typeId === typeId).length;
    }

    search() {
        this.api.getVictimizationData(this.dateStart, this.dateEnd).subscribe(i => {
            this.output = null;
            i.forEach(i2 => {
                if (!this.output) {
                    this.output = [{ typeId: i2.victimTypeId, count: 1 }];
                } else {
                    const res = this.output.filter(f => f.typeId === i2.victimTypeId);
                    if (res.length > 0) {
                        res[0].count += 1;
                    } else {
                        this.output.push({ typeId: i2.victimTypeId, count: 1 });
                    }
                }
            });
        });
    }
}
