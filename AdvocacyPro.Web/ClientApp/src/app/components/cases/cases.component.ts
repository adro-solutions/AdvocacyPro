import { Component, OnInit } from '@angular/core';
import { Case } from 'src/app/models/case.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Gender } from 'src/app/models/valueBase.model';
import { CasesService } from 'src/app/services/cases.service';
import { ValuesService } from 'src/app/services/values.service';
import { CSPNotificationService } from 'src/app/services/notification.service';
import { ActivatedRoute } from '@angular/router';
import { FormService } from 'src/app/services/form.service';

@Component({
    templateUrl: './cases.component.html',
})
export class CasesComponent implements OnInit {
    cases: Case[];
    filteredCases: Case[];
    formGroup: FormGroup;
    archived: boolean;

    genders: Gender[];

    constructor(private api: CasesService, private vService: ValuesService, private fb: FormBuilder,
        private popupService: CSPNotificationService, private route: ActivatedRoute,
        private formService: FormService) {
        this.genders = vService.genders;
    }

    ngOnInit() {
        this.route.queryParams.subscribe(p => {
            this.archived = p['archived'] === 'y';
            this.api.getAll(this.archived).subscribe(c => {
                this.cases = c;
                this.reset();
            });
        });
    }

    reset() {
        this.formGroup = this.fb.group({
            lastName: '',
            caseDateStart: null,
            caseDateEnd: null,
            dobStart: null,
            dobEnd: null,
            genderId: null
        });
        this.search(this.formGroup.value);
    }

    archive(c: Case) {
        this.popupService.showConfirm('Archive?', 'Are you sure you want to archive this item?').subscribe(confirm => {
            if (confirm.response) {
                c.archived = true;
                this.api.update(c.id, c).subscribe(() => {
                    const i = this.cases.filter((c2) => c2.id === c.id)[0];
                    this.cases.splice(this.cases.indexOf(i), 1);
                    this.search(this.formGroup.value);
                });
            }
        });
    }

    search(formValue) {
        this.filteredCases = this.cases.filter(c => {
            if (formValue['lastName'] != null && c.lastName != null
                && c.lastName.toLowerCase().indexOf(formValue['lastName'].toLowerCase()) < 0) {
                return false;
            }

            if (formValue['caseDateStart'] != null && new Date(formValue['caseDateStart']) > new Date(c.caseDate)) {
                return false;
            }

            if (formValue['caseDateEnd'] != null && new Date(formValue['caseDateEnd']) < new Date(c.caseDate)) {
                return false;
            }

            if (formValue['dobStart'] != null && new Date(formValue['dobStart']) > new Date(c.dob)) {
                return false;
            }

            if (formValue['dobEnd'] != null && new Date(formValue['dobEnd']) < new Date(c.dob)) {
                return false;
            }

            if (formValue['genderId'] != null && formValue['genderId'] !== c.genderId) {
                return false;
            }

            return true;
        });
    }
}
