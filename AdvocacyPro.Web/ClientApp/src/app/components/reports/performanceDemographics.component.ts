import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { ReportBase } from './reportBase.component';
import { Case } from 'src/app/models/case.model';
import { Race, Gender, Ethnicity } from 'src/app/models/valueBase.model';
import { ReportsService } from 'src/app/services/reports.service';
import { ValuesService } from 'src/app/services/values.service';

@Component({
    templateUrl: './performanceDemographics.component.html',
    styleUrls: ['print.css'],
    encapsulation: ViewEncapsulation.None,
})
export class PerformanceDemographicsComponent extends ReportBase implements OnInit {
    output: Case[];
    races: Race[];
    genders: Gender[];
    ethnicities: Ethnicity[];

    constructor(private api: ReportsService, private vService: ValuesService) {
        super();
        this.races = vService.races;
        this.genders = vService.genders;
        this.ethnicities = vService.ethnicities;
    }

    ngOnInit() {
        this.reset();
    }

    countRace(id: number): number {
        return this.output.filter(o => o.raceId === id).length;
    }

    countGender(id: number): number {
        return this.output.filter(o => o.genderId === id).length;
    }

    countEthnicity(id: number): number {
        return this.output.filter(o => o.ethnicityId === id).length;
    }

    search() {
        this.api.getCaseData(this.dateStart, this.dateEnd).subscribe(i => this.output = i);
    }
}
