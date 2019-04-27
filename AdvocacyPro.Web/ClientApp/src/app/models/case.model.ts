import { ContactBase } from './contactBase.model';
import * as moment from 'moment';

export class Case extends ContactBase {
    id: number;
    archived: boolean;
    caseDate: Date;
    staffUserId: number;
    statusId: number;
    constructor() {
        super();
        this.archived = false;
        this.caseDate = moment(moment().format('YYYY-MM-DDT00:00:00')).toDate();
        this.statusId = 0;
        this.staffUserId = null;
    }
}
