import { Component, ViewChild, Input, FormGroup } from '../../vendor';
import { OrganizationsService, FormService } from '../../services';
import { ModalComponent } from '../';
import { User } from '../../models';
import { Observable, Subject } from 'rxjs/Rx';

@Component({
    selector: 'member-modal',
    template: require('./member.component.html'),
    providers: [OrganizationsService]
})
export class MemberComponent {
    @ViewChild(ModalComponent) public readonly modal: ModalComponent;
    @Input() organizationId: number;
    member: User;
    formGroup: FormGroup;
    submitted: boolean = false;
    subject: Subject<User>;

    constructor(private orgService: OrganizationsService, private formService: FormService) { }
    
    public editMember(id: number): Observable<User> {
        if (id > 0) {
            this.orgService.getUser(this.organizationId, id).subscribe(
                result => {
                    this.member = result;
                    this.formService.buildFormGroup<User>(this.member, "MemberData")
                        .subscribe((fbg: FormGroup) => {
                            this.formGroup = fbg;
                            this.modal.show();
                        });
                    
                }
            );  
        } else {
            this.member = new User(this.organizationId);
            this.formService.buildFormGroup<User>(this.member, "MemberData")
                .subscribe((fbg: FormGroup) => {
                    this.formGroup = fbg;
                    this.modal.show();
                });
        }              

        this.subject = new Subject<User>();
        return this.subject.asObservable();
    }    

    submit(value: any) {
        this.submitted = true;
        if (this.formGroup.valid) {
            this.formService.buildObject(value, this.member);
            if (this.member.id == 0)
                this.orgService.createUser(this.organizationId, this.member).subscribe((member) => {
                    this.subject.next(member);
                    this.modal.hide();
                });
            else
                this.orgService.updateUser(this.organizationId, this.member.id, this.member).subscribe((member) => {
                    this.subject.next(member);
                    this.modal.hide();
                });
        }
    }
}
