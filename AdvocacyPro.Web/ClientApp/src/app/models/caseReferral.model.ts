import { TrackedBase } from './trackedBase.model';
import * as moment from 'moment';

export class CaseReferral extends TrackedBase {
    id: number;
    caseId: number;
    source: string;
    typeId: number;
    contact: string;
    followupDate: Date;
    contactDate: Date;
    notes: string;

    constructor() {
        super();
        this.id = 0;
        this.source = null;
        this.typeId = null;
        this.contact = null;
        this.followupDate = null;
        this.contactDate = moment(moment().format('YYYY-MM-DDT00:00:00')).toDate();
        this.notes = null;
    }
}
