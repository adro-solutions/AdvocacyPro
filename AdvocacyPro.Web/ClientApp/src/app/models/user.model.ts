import { UserData } from './userData.model';

export class User extends UserData {
    password: string;
    email: string;

    constructor(orgId: number) {
        super();
        this.email = '';
        this.firstName = '';
        this.id = 0;
        this.lastName = '';
        this.organizationId = orgId;
        this.password = '';
    }
}
