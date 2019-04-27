import { TrackedBase } from './trackedBase.model';
import * as moment from 'moment';

export class CaseInterview extends TrackedBase {
    id: number;
    caseId: number;
    planned: boolean;
    onSite: boolean;
    interviewDate: Date;
    interviewerPositionId: number;
    interviewerName: string;
    observers: string;
    protocolFollowed: boolean;
    caseInterviewDocumentationTypes: Array<CaseInterviewDocumentationType>;
    notes: string;

    constructor() {
        super();
        this.id = 0;
        this.planned = false;
        this.onSite = false;
        this.interviewerPositionId = null;
        this.interviewDate = moment(moment().format('YYYY-MM-DDT00:00:00')).toDate();
        this.interviewerName = null;
        this.observers = null;
        this.protocolFollowed = false;
        this.caseInterviewDocumentationTypes = [];
        this.notes = null;
    }
}

export class CaseInterviewDocumentationType {
    interviewDocumentationTypeId: number;
    caseInterviewId: number;
}
