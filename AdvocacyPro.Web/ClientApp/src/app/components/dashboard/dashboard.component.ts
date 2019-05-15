import { Component, OnInit } from '@angular/core';
import { ValuesService } from 'src/app/services/values.service';
import { Organization } from 'src/app/models/valueBase.model';
import { DashboardService } from 'src/app/services/dashboard.service';
import { StateService } from 'src/app/services/state.service';

@Component({
    template: './dashboard.component.html'
})
export class DashboardComponent implements OnInit {
    organization: Organization;
    hasFeature: Function;
    constructor(private dService: DashboardService, private vService: ValuesService, private stateService: StateService) {
        this.hasFeature = stateService.hasFeature;
    }

    ngOnInit() {
        this.organization = this.stateService.organization;
    }

    iconBg(daysOld: number): string {
        if (daysOld === -1) {
            return 'aqua';
        } else if (daysOld >= 0 && daysOld < 15) {
            return 'green';
        } else if (daysOld >= 15 && daysOld < 30) {
            return 'yellow';
        } else {
            return 'red';
        }
    }
}
