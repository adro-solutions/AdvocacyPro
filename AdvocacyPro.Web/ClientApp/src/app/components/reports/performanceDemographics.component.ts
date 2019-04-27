import { Component, OnInit, ViewEncapsulation, Observable } from '../../vendor';
import { Case, Race, Gender, Ethnicity } from '../../models';
import { ReportsService, ValuesService } from '../../services';
import { ReportBase } from '../';

@Component({
    template: require('./performanceDemographics.component.html'),
    styleUrls: ['print.css'],
    encapsulation: ViewEncapsulation.None,
    providers: [ReportsService]
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

    countRace(id: number) : number {
        return this.output.filter(o => o.raceId == id).length;
    }

    countGender(id: number): number {
        return this.output.filter(o => o.genderId == id).length;
    }

    countEthnicity(id: number): number {
        return this.output.filter(o => o.ethnicityId == id).length;
    }

    search() {
        this.api.getCaseData(this.dateStart, this.dateEnd).subscribe(i => this.output = i);
    }
}