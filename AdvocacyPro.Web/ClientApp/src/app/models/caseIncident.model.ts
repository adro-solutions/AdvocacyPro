import { TrackedBase } from './trackedBase.model';
import * as moment from 'moment';

export class CaseIncident extends TrackedBase {
    id: number;
    caseId: number;
    offenseId: number;
    reportDate: Date;
    occurrenceDate: Date;
    location: string;
    locationTypeId: number;
    staffUserId: number;
    statusId: number;
    disposition: string;
    notes: string;

    constructor() {
        super();
        this.id = 0;
        this.offenseId = null;
        this.reportDate = moment(moment().format('YYYY-MM-DDT00:00:00')).toDate();
        this.occurrenceDate = null;
        this.location = '';
        this.locationTypeId = null;
        this.staffUserId = null;
        this.statusId = null;
        this.disposition = '';
        this.notes = '';
        this.updatedById = null;
        this.updateDate = null;
    }
}
