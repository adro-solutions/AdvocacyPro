import { ContactBase } from './contactBase.model';

export class CaseEmergencyContact extends ContactBase {
    id: number;
    caseId: number;

    constructor() {
        super();
        this.id = 0;
    }
}
