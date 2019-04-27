import { Component, OnInit, Input, ViewChild, Router } from '../../vendor';
import { CasesService, ValuesService, CSPNotificationService } from '../../services';
import { InterviewDocumentationType, CaseInterview, CaseAPIEndpoints } from '../../models';
import { CaseChildListComponent } from './casechildlist.component';
import { InterviewComponent } from '../';

@Component({
    selector: "interviews",
    template: require('./interviews.component.html'),
    providers: [CasesService]
})
export class InterviewsComponent extends CaseChildListComponent<CaseInterview> implements OnInit {
    @Input() caseId: number;

    documentationTypes: Array<InterviewDocumentationType>;

    constructor(api: CasesService, private valuesService: ValuesService, popupService: CSPNotificationService,
    router: Router) {
        super(api, popupService, router);
        this.documentationTypes = valuesService.interviewDocumentationTypes;
    }

    ngOnInit() {
        this.initializeBase(this.caseId, CaseAPIEndpoints.Interviews);
    }

    documentationList(item : CaseInterview): string {
        return item.caseInterviewDocumentationTypes
            .map(dt => { return this.documentationTypes.filter(i => i.id == dt.interviewDocumentationTypeId)[0].name; })
            .join(', ');
    }
}
