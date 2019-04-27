import { Component, OnInit, ViewEncapsulation, Observable } from '../../vendor';
import { ServiceCategory, ServiceProgram } from '../../models';
import { ReportsService, ValuesService } from '../../services';
import { ReportBase } from '../';

@Component({
    template: require('./performanceServices.component.html'),
    styleUrls: ['print.css'],
    encapsulation: ViewEncapsulation.None,
    providers: [ReportsService]
})
export class PerformanceServicesComponent extends ReportBase implements OnInit {
    output: [{ programId: number, categoryId, count: number }];
    categories: ServiceCategory[];
    programs: ServiceProgram[];

    constructor(private api: ReportsService, private vService: ValuesService) {
        super();
        this.categories = vService.caseServiceCategories;
        this.programs = vService.caseServicePrograms;
    }

    ngOnInit() {
        this.reset();
    }
    
    getPrograms(categoryId: number): ServiceProgram[] {
        return this.programs.filter(p => p.categoryId == categoryId);
    }

    countProgram(categoryId: number, programId: number): number {
        return this.output.filter(o => o.categoryId == categoryId && o.programId == programId).length;
    }

    search() {
        this.api.getServiceData(this.dateStart, this.dateEnd).subscribe(i => {
            this.output = null;
            i.forEach(i => {
                if (!this.output) {
                    this.output = [{ programId: i.programId, categoryId: i.categoryId, count: 1 }];
                }
                else {
                    var res = this.output.filter(f => f.programId == i.programId && f.categoryId == i.categoryId);
                    if (res.length > 0) {
                        res[0].count += 1;
                    } else {
                        this.output.push({ programId: i.programId, categoryId: i.categoryId, count: 1 });
                    }
                }
            });
        });
    }
}