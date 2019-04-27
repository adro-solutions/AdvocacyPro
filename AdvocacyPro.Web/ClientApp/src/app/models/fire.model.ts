import { TrackedBase } from './trackedBase.model';
import * as moment from 'moment';

export class Fire extends TrackedBase {
    id: number;
    reportDate: Date;
    occurrenceDate: Date;
    location: string;
    locationTypeId: number;
    statusId: number;
    causeId: number;
    disposition: string;
    notes: string;
    staffUserId: number;
    archived: boolean;

    constructor() {
        super();
        this.id = 0;
        this.reportDate = moment(moment().format('YYYY-MM-DDT00:00:00')).toDate();
        this.occurrenceDate = moment(moment().format('YYYY-MM-DDT00:00:00')).toDate();
        this.location = null;
        this.locationTypeId = null;
        this.statusId = 0;
        this.causeId = null;
        this.disposition = null;
        this.notes = null;
        this.staffUserId = null;
        this.archived = false;
    }
}
