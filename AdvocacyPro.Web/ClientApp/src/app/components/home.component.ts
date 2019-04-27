import { Component, OnInit } from '../vendor';
import { StateService } from '../services';
import { UserData } from '../models';

@Component({
    selector: 'home',
    template: require('./home.component.html')
})
export class HomeComponent implements OnInit {
    user: UserData;

    constructor(private stateService: StateService) { }

    ngOnInit() {
        this.user = this.stateService.user;
    }
}
