import { TrackedBase } from './trackedBase.model';

export class ContactBase extends TrackedBase {
    lastName: string;
    firstName: string;
    middleName: string;
    address: string;
    city: string;
    stateId: number;
    zipCode: string;
    homePhone: string;
    cellPhone: string;
    workPhone: string;
    email: string;
    dob: Date;
    genderId: number;
    raceId: number;
    age: number;
    ethnicityId: number;

    constructor() {
        super();
        this.lastName = null;
        this.firstName = null;
        this.middleName = null;
        this.address = null;
        this.city = null;
        this.stateId = null;
        this.zipCode = null;
        this.homePhone = null;
        this.cellPhone = null;
        this.workPhone = null;
        this.email = null;
        this.dob = null;
        this.genderId = null;
        this.raceId = null;
        this.age = null;
        this.ethnicityId = null;
    }
}
