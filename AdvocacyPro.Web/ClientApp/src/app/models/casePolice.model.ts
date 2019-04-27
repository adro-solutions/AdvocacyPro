import { TrackedBase } from './trackedBase.model';

export class CasePolice extends TrackedBase {
    id: number;
    policeDepartment: string;
    policeSequenceNo: string;
    policeCaseNo: string;
    firstName: string;
    lastName: string;
    policeClosedDate: Date;
    policeOutcome: string;
    notes: string;

    constructor() {
        super();
        this.id = 0;
        this.policeDepartment = null;
        this.policeSequenceNo = null;
        this.policeCaseNo = null;
        this.firstName = null;
        this.lastName = null;
        this.policeClosedDate = null;
        this.policeOutcome = null;
        this.notes = null;
    }
}
