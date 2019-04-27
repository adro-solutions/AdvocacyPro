import { TrackedBase } from './trackedBase.model';
import * as moment from 'moment';

export class CasePayment extends TrackedBase {
    id: number;
    caseId: number;
    paymentCategoryId: number;
    amountSubmitted: number;
    amountApproved: number;
    approvedById: number;
    approvedDate: Date;
    submittedById: number;
    submittedDate: Date;
    claimId: string;
    payorId: number;
    comments: string;

    constructor() {
        super();
        this.id = 0;
        this.paymentCategoryId = null;
        this.amountSubmitted = null;
        this.amountApproved = null;
        this.approvedDate = null;
        this.approvedById = null;
        this.submittedDate = null;
        this.submittedDate = null;
        this.submittedById = null;
        this.claimId = null;
        this.payorId = null;
        this.comments = null;
    }
}
