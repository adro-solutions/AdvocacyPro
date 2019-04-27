import { TrackedBase } from './trackedBase.model';
import * as moment from 'moment';

export class CaseService extends TrackedBase {
    id: number;
    categoryId: number;
    programId: number;
    populationId: number;
    startDate: Date;
    endDate: Date;
    notes: string;

    constructor() {
        super();
        this.id = 0;
        this.categoryId = null;
        this.programId = null;
        this.populationId = null;
        this.startDate = moment(moment().format('YYYY-MM-DDT00:00:00')).toDate();
        this.endDate = null;
        this.notes = null;
    }
}
