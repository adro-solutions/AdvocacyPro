import { CaseChildListComponent } from './casechildlist.component';
import { Component, OnInit, Input } from '@angular/core';
import { CasesService } from 'src/app/services/cases.service';
import { CaseInterview } from 'src/app/models/caseInterview.model';
import { InterviewDocumentationType } from 'src/app/models/valueBase.model';
import { ValuesService } from 'src/app/services/values.service';
import { CSPNotificationService } from 'src/app/services/notification.service';
import { Router } from '@angular/router';
import { CaseAPIEndpoints } from 'src/app/models/constants';

@Component({
    selector: 'app-interviews',
    template: require('./interviews.component.html'),
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

    documentationList(item: CaseInterview): string {
        return item.caseInterviewDocumentationTypes
            .map(dt => this.documentationTypes.filter(i => i.id === dt.interviewDocumentationTypeId)[0].name)
            .join(', ');
    }
}
