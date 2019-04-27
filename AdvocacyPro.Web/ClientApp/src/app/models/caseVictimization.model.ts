import { TrackedBase } from './trackedBase.model';
import * as moment from 'moment';

export class CaseVictimization extends TrackedBase {
    id: number;
    caseId: number;
    victimTypeId: number;
    reportingAgency: string;
    reportNumber: string;
    startDate: Date;
    reportDetails: string;
    comments: string;

    constructor() {
        super();
        this.id = 0;
        this.victimTypeId = null;
        this.reportingAgency = null;
        this.reportNumber = null;
        this.startDate = moment(moment().format('YYYY-MM-DDT00:00:00')).toDate();
        this.reportDetails = null;
        this.comments = null;
    }
}
