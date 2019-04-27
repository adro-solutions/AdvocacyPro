import { Component, ViewChild, Input, OnInit, FormArray, ActivatedRoute, Router } from '../../vendor';
import { CasesService, FormService, ValuesService, StateService } from '../../services';
import { ModalComponent } from '../';
import { CaseInterview, UserData, InterviewerPosition, CaseAPIEndpoints, InterviewDocumentationType, ObjectType } from '../../models';
import { CaseChildComponent } from './casechild.component';

@Component({
    selector: 'interview-modal',
    template: require('./interview.component.html'),
    styleUrls: ['interview.component.css'],
    providers: [CasesService]
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
            let newItem = new CaseInterview();
            super.initializeBase(+r["caseId"], ObjectType.CaseInterview, newItem, CaseAPIEndpoints.Interviews);
            this.editItem(+r["id"]);

        });
    }

    get formDocumentationTypes(): FormArray {
        return this.formGroup.get('caseInterviewDocumentationTypes') as FormArray
    }
}
