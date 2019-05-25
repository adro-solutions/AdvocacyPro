import { OnInit, Component } from '@angular/core';
import { UserData } from '../models/userData.model';
import { StateService } from '../services/state.service';

@Component({
    templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
    user: UserData;

    constructor(private stateService: StateService) { }

    ngOnInit() {
        this.user = this.stateService.user;
    }
}
