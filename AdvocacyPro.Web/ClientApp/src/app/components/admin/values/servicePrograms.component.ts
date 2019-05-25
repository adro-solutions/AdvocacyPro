import { CSPNotificationService } from './../../../services/notification.service';
import { ValueAPIEndpoints } from './../../../models/constants';
import { ValuesService } from './../../../services/values.service';
import { ServiceProgram } from './../../../models/valueBase.model';
import { Component, OnInit } from '@angular/core';

@Component({
    templateUrl: './servicePrograms.component.html'
})
export class ServiceProgramsComponent implements OnInit {
    servicePrograms: ServiceProgram[];

    constructor(private api: ValuesService, private popupService: CSPNotificationService) { }

    ngOnInit() {
        this.api.getAll<ServiceProgram>(ValueAPIEndpoints.serviceprograms).subscribe(a => {
            this.servicePrograms = a;
        });
    }


    delete(id: number) {
        this.popupService.showConfirm('Delete?', 'Are you sure you want to delete this item?').subscribe(confirm => {
            if (confirm.response) {
                this.api.delete<ServiceProgram>(ValueAPIEndpoints.serviceprograms, id).subscribe(() => {
                    const i = this.servicePrograms.filter((c) => c.id === id)[0];
                    this.servicePrograms.splice(this.servicePrograms.indexOf(i), 1);
                });
            }
        });
    }
}
