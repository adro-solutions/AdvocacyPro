import { TrackedBase } from './trackedBase.model';

export class CaseNote extends TrackedBase {
    id: number;
    notes: string;

    constructor() {
        super();
        this.id = 0;
        this.notes = null;
    }
}
