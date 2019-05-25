import { ValueAPIEndpoints } from './../../models/constants';
import { StateService } from './../../services/state.service';
import { FormService } from './../../services/form.service';
import { FeaturesService } from './../../services/features.service';
import { ValuesService } from './../../services/values.service';
import { OrganizationsService } from './../../services/organizations.service';
import { Feature } from './../../models/feature.model';
import { Organization, OrganizationType } from './../../models/valueBase.model';
import { FileUploadComponent } from './../fileUpload.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin } from 'rxjs';


@Component({
    templateUrl: './organization.component.html',
})
export class OrganizationComponent implements OnInit {
    @ViewChild(FileUploadComponent) public readonly fileUpload: FileUploadComponent;
    id: number;
    organization: Organization;
    organizationTypes: OrganizationType[];
    features: Feature[];
    formGroup: FormGroup;
    featureGroup: FormGroup;
    submitted = false;
    tabIndex: number;
    logo: string;
    hasFeature: Function;

    constructor(private api: OrganizationsService, private otApi: ValuesService, private fApi: FeaturesService,
        private route: ActivatedRoute, private formService: FormService, private router: Router,
        private stateService: StateService) {
        this.hasFeature = stateService.hasFeature;
    }

    ngOnInit() {
        this.tabIndex = 0;
        this.otApi.getAll<OrganizationType>(ValueAPIEndpoints.organizationtypes).subscribe(ot => this.organizationTypes = ot);

        this.route.params.subscribe(params => {
            this.id = +params['id'];

            if (this.id > 0) {
                this.api.get(this.id).subscribe(a => {
                    this.organization = a;
                    this.logo = 'data:image/png;base64,' + a.logo;
                    this.formService.buildFormGroup<Organization>(this.organization, 'Organization')
                        .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
                });

                forkJoin(this.fApi.getAll(),
                    this.api.getFeatures(this.id)).subscribe(d => {
                        this.features = d[0];
                        this.featureGroup = this.formService.buildFormGroupFromArray(d[0], d[1], 'value', 'value');
                    });
            } else {
                this.organization = new Organization();
                this.formService.buildFormGroup<Organization>(this.organization, 'Organization')
                    .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
            }
        });

    }

    submit(value: any) {
        this.submitted = true;
        if (this.formGroup.valid) {
            this.formService.buildObject(value, this.organization);
            if (this.id === 0) {
                this.api.create(this.organization).subscribe(() => this.router.navigate(['/admin/organizations']));
            } else {
                this.api.update(this.id, this.organization).subscribe(() => {
                    this.router.navigate(['/admin/organizations']);
                });
            }
        }
    }

    submitFeatures(value: any) {
        this.submitted = true;
        if (this.featureGroup.valid) {
            const features = new Array<Feature>();
            this.formService.buildArrayFromForm(value, features, true, 'value');

            if (this.id > 0) {
                this.api.updateFeatures(this.id, features).subscribe(() => this.router.navigate(['/admin/organizations']));
            }
        }
    }

    uploadLogo() {
        this.api.uploadLogo(this.id, this.fileUpload.formData).subscribe((org) => {
            this.logo = 'data:image/png;base64,' + org.logo;
        });
    }

    lookupZip() {
        this.formService.completeZip(this.formGroup);
    }
}
