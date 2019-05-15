import { Product } from './../../enums/product.enum';
import { CSPNotificationService } from './../../services/notification.service';
import { OrganizationsService } from './../../services/organizations.service';
import { Organization } from './../../models/valueBase.model';
import { Component, OnInit } from '@angular/core';

@Component({
    template: './organizations.component.html',
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
        this.popupService.showConfirm('Delete?', 'Are you sure you want to delete this item?').subscribe(confirm => {
            if (confirm.response) {
                this.api.delete(id).subscribe(() => {
                    const i = this.organizations.filter((org) => org.id === id)[0];
                    this.organizations.splice(this.organizations.indexOf(i), 1);
                });
            }
        });
    }

    productText(product: Product): string {
        switch (product) {
            case Product.AdvocacyPro:
                return 'AdvocacyPro';
            case Product.CampusSafetyPro:
                return 'CampusSafetyPro';
        }
    }
}
