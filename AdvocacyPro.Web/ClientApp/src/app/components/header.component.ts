import { Component, OnInit } from '@angular/core';
import { UserData } from '../models/userData.model';
import { Organization } from '../models/valueBase.model';
import { StateService } from '../services/state.service';
import { DashboardService } from '../services/dashboard.service';
import { ValuesService } from '../services/values.service';

@Component({
    selector: 'app-site-header',
    templateUrl: './header.component.html',
    styleUrls: ['header.component.css']
})
export class HeaderComponent implements OnInit {
    user: UserData;
    organization: Organization;
    hasFeature: Function;

    constructor(private stateService: StateService, private dService: DashboardService, private vService: ValuesService) {
        this.hasFeature = stateService.hasFeature;
    }

    ngOnInit() {
        this.user = this.stateService.user;
        this.organization = this.stateService.organization;
        this.dService.refresh();
    }

    toggleNav(menuItem: string) {
        this.stateService.navsOpen[menuItem] = !this.stateService.navsOpen[menuItem];
    }

    isOpen(menuItem: string): boolean {
        return this.stateService.navsOpen[menuItem];
    }

    numberClass(daysOld: number): string {
        if (daysOld === -1) {
            return 'primary';
        } else if (daysOld >= 0 && daysOld < 15) {
            return 'success';
        } else if (daysOld >= 15 && daysOld < 30) {
            return 'warning';
        } else {
            return 'danger';
        }
    }
}
