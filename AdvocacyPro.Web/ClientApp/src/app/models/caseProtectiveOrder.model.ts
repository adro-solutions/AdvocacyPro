import { TrackedBase } from './trackedBase.model';
import * as moment from 'moment';

export class CaseProtectiveOrder extends TrackedBase {
    id: number;
    caseId: number;
    orderTypeId: number;
    orderStatusId: number;
    startDate: Date;
    endDate: Date;
    notes: string;

    constructor() {
        super();
        this.id = 0;
        this.orderTypeId = null;
        this.orderStatusId = null;
        this.startDate = moment(moment().format('YYYY-MM-DDT00:00:00')).toDate();
        this.endDate = null;
        this.notes = null;
    }
}
