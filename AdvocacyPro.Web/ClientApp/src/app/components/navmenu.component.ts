import { Component, OnInit } from '../vendor';
import { StateService } from '../services';
import { UserData, Organization } from '../models';

@Component({
    selector: 'nav-menu',
    template: require('./navmenu.component.html'),
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
