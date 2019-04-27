import { TrackedBase } from './trackedBase.model';

export class CaseLetter extends TrackedBase {
    id: number;
    caseId: number;
    letterTypeId: number;
    languageId: number;
    notes: string;

    constructor() {
        super();
        this.id = 0;
        this.letterTypeId = null;
        this.languageId = null;
        this.notes = null;
    }
}
