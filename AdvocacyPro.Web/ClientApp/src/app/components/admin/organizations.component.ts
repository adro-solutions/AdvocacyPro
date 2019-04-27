import { Component, OnInit } from '../../vendor';
import { OrganizationsService, CSPNotificationService } from '../../services';
import { Organization } from '../../models';
import { Product } from '../../enums';

@Component({
    template: require('./organizations.component.html'),
    providers: [OrganizationsService]
})
export class OrganizationsComponent implements OnInit {
    organizations: Organization[];

    constructor(private api: OrganizationsService, private popupService: CSPNotificationService) { }

    ngOnInit() {
        this.api.getAll().subscribe(a => {
            this.organizations = a;
        });
    }


    delete(id: number) {
        this.popupService.showConfirm("Delete?", "Are you sure you want to delete this item?").subscribe(confirm => {
            if (confirm.response)
                this.api.delete(id).subscribe(() => {
                    let i = this.organizations.filter((org) => { return org.id === id })[0];
                    this.organizations.splice(this.organizations.indexOf(i), 1);

                });
        });
    }

    productText(product: Product): string {
        switch (product) {
            case Product.AdvocacyPro:
                return "AdvocacyPro";
            case Product.CampusSafetyPro:
                return "CampusSafetyPro";
        }
    }
}
