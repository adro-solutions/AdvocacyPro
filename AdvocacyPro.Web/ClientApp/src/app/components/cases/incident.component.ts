import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CasesService } from 'src/app/services/cases.service';
import { LocationsService } from 'src/app/services/locations.service';
import { CaseIncident } from 'src/app/models/caseIncident.model';
import { Offense, LocationType, Status } from 'src/app/models/valueBase.model';
import { UserData } from 'src/app/models/userData.model';
import { FormService } from 'src/app/services/form.service';
import { ValuesService } from 'src/app/services/values.service';
import { StateService } from 'src/app/services/state.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    template: require('./incident.component.html'),
    providers: [CasesService, LocationsService]
})
export class IncidentComponent extends CaseChildComponent<CaseIncident> implements OnInit {
    offenses: Offense[];
    locationTypes: LocationType[];
    users: UserData[];
    statuses: Status[];
    locations: string[];
    oLocations: string[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, private stateService: StateService, private locationsService: LocationsService,
        router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.offenses = valueService.offenses;
        this.locationTypes = valueService.locationTypes;
        this.users = valueService.users;
        this.statuses = valueService.statuses;
    }

    ngOnInit(): void {
        const newItem = new CaseIncident();
        this.locationsService.getAll().subscribe(d => this.oLocations = d);
        newItem.staffUserId = this.stateService.user.id;
        this.activeRoute.params.subscribe(r => {
            super.initializeBase(+r['caseId'], ObjectType.CaseIncident, newItem, CaseAPIEndpoints.Incidents);
            this.editItem(+r['id']);

        });
    }

    search(event) {
        this.locations = this.oLocations.filter(l => l.toLowerCase().indexOf(event.query.toString().toLowerCase()) >= 0);
    }
}
