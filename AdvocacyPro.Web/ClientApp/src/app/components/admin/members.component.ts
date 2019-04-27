import { Component, OnInit, Input, ViewChild } from '../../vendor';
import { OrganizationsService, CSPNotificationService, StateService } from '../../services';
import { User, UserData } from '../../models';
import { MemberComponent, MemberFeatureComponent } from '../';

@Component({
    selector: "members",
    template: require('./members.component.html'),
    providers: [OrganizationsService]
})
export class MembersComponent implements OnInit {
    members: User[];
    user: UserData;
    @ViewChild(MemberComponent) public readonly member: MemberComponent;
    @ViewChild(MemberFeatureComponent) public readonly memberFeature: MemberFeatureComponent;
    @Input() organizationId: number;
    hasFeature: Function;

    constructor(private api: OrganizationsService, private popupService: CSPNotificationService, private stateService: StateService) {
        this.hasFeature = stateService.hasFeature;
    }

    ngOnInit() {
        if (!this.organizationId)
            this.organizationId = this.stateService.user.organizationId;

        this.user = this.stateService.user;

        this.api.getUsers(this.organizationId).subscribe(a => {
            this.members = a;
        });
    }

    edit(id: number) {
        this.member.editMember(id).subscribe(member => {
            if (id == 0)
                this.members.push(member);
            else {
                let m = this.members.filter((member) => { return member.id === id })[0];

                for (let key of Object.keys(member)) {
                    m[key] = member[key];
                }
            }
        });
    }

    editFeatures(id: number) {
        this.memberFeature.editMember(id).subscribe(member => {
            if (id == 0)
                this.members.push(member);
            else {
                let m = this.members.filter((member) => { return member.id === id })[0];

                for (let key of Object.keys(member)) {
                    m[key] = member[key];
                }
            }
        });
    }

    delete(id: number) {
        this.popupService.showConfirm("Delete?", "Are you sure you want to delete this item?").subscribe(confirm => {
            if (confirm.response)
                this.api.deleteUser(this.organizationId, id).subscribe(() => {
                    let i = this.members.filter((member) => { return member.id === id })[0];
                    this.members.splice(this.members.indexOf(i), 1);

                });
        });
    }
}
