import { Component, OnInit } from '@angular/core';
import { UserData } from '../models/userData.model';
import { Organization } from '../models/valueBase.model';
import { StateService } from '../services/state.service';

@Component({
    selector: 'app-nav-menu',
    template: './navmenu.component.html',
    styleUrls: ['navmenu.component.css']
})
export class NavMenuComponent implements OnInit {
    user: UserData;
    organization: Organization;
    hasFeature: Function;

    constructor(private stateService: StateService) {
        this.hasFeature = stateService.hasFeature;
    }

    ngOnInit() {
        this.user = this.stateService.user;
        this.organization = this.stateService.organization;
    }

    toggleNav(menuItem: string) {
        this.stateService.navsOpen[menuItem] = !this.stateService.navsOpen[menuItem];
    }

    isOpen(menuItem: string): boolean {
        return this.stateService.navsOpen[menuItem];
    }
}
