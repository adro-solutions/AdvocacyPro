import { Component, OnInit } from '../../../vendor';
import { ValuesService, CSPNotificationService } from '../../../services';
import { ServiceProgram, ValueAPIEndpoints } from '../../../models';

@Component({
    template: require('./servicePrograms.component.html')
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
        this.popupService.showConfirm("Delete?", "Are you sure you want to delete this item?").subscribe(confirm => {
            if (confirm.response)
                this.api.delete<ServiceProgram>(ValueAPIEndpoints.serviceprograms, id).subscribe(() => {
                    let i = this.servicePrograms.filter((c) => { return c.id === id })[0];
                    this.servicePrograms.splice(this.servicePrograms.indexOf(i), 1);

                });
        });
    }
}
