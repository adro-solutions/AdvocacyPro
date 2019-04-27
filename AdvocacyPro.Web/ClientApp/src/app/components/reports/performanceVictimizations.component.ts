import { Component, OnInit, ViewEncapsulation, Observable } from '../../vendor';
import { CaseVictimization, VictimType } from '../../models';
import { ReportsService, ValuesService } from '../../services';
import { ReportBase } from '../';

@Component({
    template: require('./performanceVictimizations.component.html'),
    styleUrls: ['print.css'],
    encapsulation: ViewEncapsulation.None,
    providers: [ReportsService]
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
        return this.output.filter(o => o.typeId == typeId).length;
    }
   
    search() {
        this.api.getVictimizationData(this.dateStart, this.dateEnd).subscribe(i => {
            this.output = null;
            i.forEach(i => {
                if (!this.output) {
                    this.output = [{ typeId: i.victimTypeId, count: 1 }];
                }
                else {
                    var res = this.output.filter(f => f.typeId == i.victimTypeId);
                    if (res.length > 0) {
                        res[0].count += 1;
                    } else {
                        this.output.push({ typeId: i.victimTypeId, count: 1 });
                    }
                }
            });
        });
    }
}