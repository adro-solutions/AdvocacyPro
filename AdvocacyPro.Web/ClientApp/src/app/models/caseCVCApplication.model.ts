import { TrackedBase } from './trackedBase.model';
import * as moment from 'moment';

export class CaseCVCApplication extends TrackedBase {
    id: number;
    caseId: number;
    cvcNumber: string;
    cvcDate: Date;
    applicationStatusId: number;
    offenseTypeId: number;
    referralTypeId: number;
    referralOther: string;
    defendant: string;
    notes: string;

    constructor() {
        super();
        this.id = 0;
        this.cvcNumber = null;
        this.cvcDate = moment(moment().format('YYYY-MM-DDT00:00:00')).toDate();
        this.applicationStatusId = null;
        this.offenseTypeId = null;
        this.referralTypeId = null;
        this.referralOther = null;
        this.defendant = null;
        this.notes = null;
    }
}
