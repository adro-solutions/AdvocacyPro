import { Component, ViewChild, Input, FormGroup, noop } from '../../vendor';
import { OrganizationsService, FormService } from '../../services';
import { ModalComponent } from '../';
import { User, Feature } from '../../models';
import { Observable, Subject } from 'rxjs/Rx';

@Component({
    selector: 'member-feature-modal',
    template: require('./memberFeature.component.html'),
    providers: [OrganizationsService]
})
export class MemberFeatureComponent {
    @ViewChild(ModalComponent) public readonly modal: ModalComponent;
    @Input() organizationId: number;
    memberId: number;
    features: Feature[];
    formGroup: FormGroup;
    submitted: boolean = false;
    subject: Subject<User>;

    constructor(private orgService: OrganizationsService, private formService: FormService) {
    }

    public editMember(id: number): Observable<User> {
        if (id > 0) {
            this.memberId = id;
            Observable.forkJoin(
                this.orgService.getFeatures(this.organizationId),
                this.orgService.getUserFeatures(this.organizationId, id)
            ).subscribe(d => {
                this.features = d[0];
                this.formGroup = this.formService.buildFormGroupFromArray(d[0], d[1], "value", "value");
                this.modal.show();
            }, error => noop());
        }

        this.subject = new Subject<User>();
        return this.subject.asObservable();
    }

    submit(value: any) {
        this.submitted = true;
        if (this.formGroup.valid) {
            let features = new Array<Feature>();
            this.formService.buildArrayFromForm(value, features, true, "value");

            if (this.memberId > 0)
                this.orgService
                    .updateUserFeatures(this.organizationId, this.memberId, features)
                    .subscribe(() => this.modal.hide());
        }
    }
}
