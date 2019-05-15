import { FormService } from './../../services/form.service';
import { OrganizationsService } from './../../services/organizations.service';
import { User } from './../../models/user.model';
import { Feature } from './../../models/feature.model';
import { Component, ViewChild, Input } from '@angular/core';
import { ModalComponent } from '../modal.component';
import { FormGroup } from '@angular/forms';
import { Subject, Observable, forkJoin, noop } from 'rxjs';

@Component({
    selector: 'app-member-feature-modal',
    template: './memberFeature.component.html',
})
export class MemberFeatureComponent {
    @ViewChild(ModalComponent) public readonly modal: ModalComponent;
    @Input() organizationId: number;
    memberId: number;
    features: Feature[];
    formGroup: FormGroup;
    submitted = false;
    subject: Subject<User>;

    constructor(private orgService: OrganizationsService, private formService: FormService) {
    }

    public editMember(id: number): Observable<User> {
        if (id > 0) {
            this.memberId = id;
            forkJoin(
                this.orgService.getFeatures(this.organizationId),
                this.orgService.getUserFeatures(this.organizationId, id)
            ).subscribe(d => {
                this.features = d[0];
                this.formGroup = this.formService.buildFormGroupFromArray(d[0], d[1], 'value', 'value');
                this.modal.show();
            }, error => noop());
        }

        this.subject = new Subject<User>();
        return this.subject.asObservable();
    }

    submit(value: any) {
        this.submitted = true;
        if (this.formGroup.valid) {
            const features = new Array<Feature>();
            this.formService.buildArrayFromForm(value, features, true, 'value');

            if (this.memberId > 0) {
                this.orgService
                    .updateUserFeatures(this.organizationId, this.memberId, features)
                    .subscribe(() => this.modal.hide());
                }
        }
    }
}
