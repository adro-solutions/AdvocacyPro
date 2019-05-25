import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { ReportsService } from 'src/app/services/reports.service';
import { ReportBase } from './reportBase.component';
import { ServiceCategory, ServiceProgram } from 'src/app/models/valueBase.model';
import { ValuesService } from 'src/app/services/values.service';

@Component({
    templateUrl: './performanceServices.component.html',
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
        return this.programs.filter(p => p.categoryId === categoryId);
    }

    countProgram(categoryId: number, programId: number): number {
        return this.output.filter(o => o.categoryId === categoryId && o.programId === programId).length;
    }

    search() {
        this.api.getServiceData(this.dateStart, this.dateEnd).subscribe(i => {
            this.output = null;
            i.forEach(i2 => {
                if (!this.output) {
                    this.output = [{ programId: i2.programId, categoryId: i2.categoryId, count: 1 }];
                } else {
                    const res = this.output.filter(f => f.programId === i2.programId && f.categoryId === i2.categoryId);
                    if (res.length > 0) {
                        res[0].count += 1;
                    } else {
                        this.output.push({ programId: i2.programId, categoryId: i2.categoryId, count: 1 });
                    }
                }
            });
        });
    }
}
