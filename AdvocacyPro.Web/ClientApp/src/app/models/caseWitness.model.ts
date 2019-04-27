import { ContactBase } from './contactBase.model';
import * as moment from 'moment';

export class CaseWitness extends ContactBase {
    id: number;
    interviewDate: Date;
    relationshipTypeId: number;
    notes: string;

    constructor() {
        super();
        this.id = 0;
        this.interviewDate = moment(moment().format('YYYY-MM-DDT00:00:00')).toDate();
        this.relationshipTypeId = null;
        this.notes = null;
    }
}
