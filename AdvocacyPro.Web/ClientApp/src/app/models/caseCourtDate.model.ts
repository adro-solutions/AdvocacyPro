import { TrackedBase } from './trackedBase.model';
import * as moment from 'moment';

export class CaseCourtDate extends TrackedBase {
    id: number;
    caseId: number;
    docketNumber: string;
    docketTypeId: number;
    court: string;
    police: string;
    arrestDate: Date;
    bondAmount: number;
    bondTypeId: number;
    startDate: Date;
    endDate: Date;
    purpose: string;
    reason: string;

    constructor() {
        super();
        this.id = 0;
        this.docketNumber = null;
        this.docketTypeId = null;
        this.court = null;
        this.police = null;
        this.arrestDate = null;
        this.bondAmount = 0;
        this.bondTypeId = null;
        this.startDate = moment(moment().format('YYYY-MM-DDT00:00:00')).toDate();
        this.endDate = null;
        this.purpose = null;
        this.reason = null;
    }
}
