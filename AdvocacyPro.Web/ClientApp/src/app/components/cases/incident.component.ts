﻿import { Component, ViewChild, Input, OnInit, Router, ActivatedRoute } from '../../vendor';
import { CasesService, FormService, ValuesService, StateService, LocationsService } from '../../services';
import { CaseIncident, Offense, LocationType, UserData, Status, CaseAPIEndpoints, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

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
        let newItem = new CaseIncident();
        this.locationsService.getAll().subscribe(d => this.oLocations = d);
        newItem.staffUserId = this.stateService.user.id;
        this.activeRoute.params.subscribe(r => {
            super.initializeBase(+r["caseId"], ObjectType.CaseIncident, newItem, CaseAPIEndpoints.Incidents);
            this.editItem(+r["id"]);

        });
    }

    search(event) {
        this.locations = this.oLocations.filter(l => l.toLowerCase().indexOf(event.query.toString().toLowerCase()) >= 0);
    }
}
