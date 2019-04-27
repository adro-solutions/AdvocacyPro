import { ContactBase } from './contactBase.model';

export class CaseOffender extends ContactBase {
    id: number;
    priorOffenses: boolean;
    numberOfOffenses: number;
    relationshipTypeId: number;
    comments: string;
    ageGroupingId: number;

    constructor() {
        super();
        this.id = 0;
        this.priorOffenses = false;
        this.numberOfOffenses = 0;
        this.relationshipTypeId = null;
        this.comments = null;
        this.ageGroupingId = null;
    }
}
