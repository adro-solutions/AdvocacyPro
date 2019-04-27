import { TrackedBase } from './trackedBase.model';
import * as moment from 'moment';

export class CaseContact extends TrackedBase {
    id: number;
    contactTypeId: number;
    contactDate: Date;
    notes: string;

    constructor() {
        super();
        this.id = 0;
        this.contactTypeId = null;
        this.contactDate = moment(moment().format('YYYY-MM-DDT00:00:00')).toDate();
        this.notes = null;
    }
}
