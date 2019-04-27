import { TrackedBase } from './trackedBase.model';

export class CaseDocument extends TrackedBase {
    id: number;
    fileName: string;
    documentTypeId: number;
    notes: string;

    constructor() {
        super();
        this.id = 0;
        this.fileName = null;
        this.documentTypeId = null;
        this.notes = null;
    }
}
