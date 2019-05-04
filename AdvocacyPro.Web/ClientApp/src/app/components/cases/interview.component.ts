import { CaseChildComponent } from './casechild.component';
import { Component, OnInit } from '@angular/core';
import { CasesService } from 'src/app/services/cases.service';
import { CaseInterview } from 'src/app/models/caseInterview.model';
import { InterviewerPosition, InterviewDocumentationType } from 'src/app/models/valueBase.model';
import { FormService } from 'src/app/services/form.service';
import { ValuesService } from 'src/app/services/values.service';
import { StateService } from 'src/app/services/state.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType, CaseAPIEndpoints } from 'src/app/models/constants';
import { FormArray } from '@angular/forms';

@Component({
    template: require('./interview.component.html'),
    styleUrls: ['interview.component.css'],
})
export class InterviewComponent extends CaseChildComponent<CaseInterview> implements OnInit {
    interviewerPositions: InterviewerPosition[];
    interviewDocumentationTypes: InterviewDocumentationType[];

    constructor(private _api: CasesService, private _formService: FormService,
        private valueService: ValuesService, private stateService: StateService,
        router: Router, private activeRoute: ActivatedRoute) {
        super(_api, _formService, router);
        this.interviewerPositions = valueService.interviewerPositions;
        this.interviewDocumentationTypes = valueService.interviewDocumentationTypes;
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            const newItem = new CaseInterview();
            super.initializeBase(+r['caseId'], ObjectType.CaseInterview, newItem, CaseAPIEndpoints.Interviews);
            this.editItem(+r['id']);
        });
    }

    get formDocumentationTypes(): FormArray {
        return this.formGroup.get('caseInterviewDocumentationTypes') as FormArray;
    }
}
