import { StateService } from './../../services/state.service';
import { CSPNotificationService } from './../../services/notification.service';
import { OrganizationsService } from './../../services/organizations.service';
import { UserData } from './../../models/userData.model';
import { User } from './../../models/user.model';
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { MemberComponent } from './member.component';
import { MemberFeatureComponent } from './memberFeature.component';

@Component({
    selector: 'app-members',
    template: require('./members.component.html'),
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
        if (!this.organizationId) {
            this.organizationId = this.stateService.user.organizationId;
        }

        this.user = this.stateService.user;

        this.api.getUsers(this.organizationId).subscribe(a => {
            this.members = a;
        });
    }

    edit(id: number) {
        this.member.editMember(id).subscribe(member => {
            if (id === 0) {
                this.members.push(member);
            } else {
                const m = this.members.filter(o => o.id === id )[0];

                for (const key of Object.keys(member)) {
                    m[key] = member[key];
                }
            }
        });
    }

    editFeatures(id: number) {
        this.memberFeature.editMember(id).subscribe(member => {
            if (id === 0) {
                this.members.push(member);
            } else {
                const m = this.members.filter(o => o.id === id )[0];

                for (const key of Object.keys(member)) {
                    m[key] = member[key];
                }
            }
        });
    }

    delete(id: number) {
        this.popupService.showConfirm('Delete?', 'Are you sure you want to delete this item?').subscribe(confirm => {
            if (confirm.response) {
                this.api.deleteUser(this.organizationId, id).subscribe(() => {
                    const i = this.members.filter(m => m.id === id )[0];
                    this.members.splice(this.members.indexOf(i), 1);
                });
            }
        });
    }
}
