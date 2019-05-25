import { Component, OnInit, ViewChild } from '@angular/core';
import { FileUploadComponent } from '../fileUpload.component';
import { CaseDocument } from 'src/app/models/caseDocument.model';
import { FormGroup } from '@angular/forms';
import { CasesService } from 'src/app/services/cases.service';
import { FormService } from 'src/app/services/form.service';
import { ValuesService } from 'src/app/services/values.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ObjectType } from 'src/app/models/constants';
import { DocumentType } from 'src/app/models/valueBase.model';

@Component({
    templateUrl: './document.component.html',
})
export class DocumentComponent implements OnInit {
    @ViewChild(FileUploadComponent) public readonly fileUpload: FileUploadComponent;
    document: CaseDocument;
    formGroup: FormGroup;
    submitted = false;
    caseId: number;
    caseDocumentTypes: DocumentType[];

    constructor(private api: CasesService, private formService: FormService,
        private valueService: ValuesService, private router: Router, private activeRoute: ActivatedRoute) {
        this.caseDocumentTypes = valueService.caseDocumentTypes;
    }

    ngOnInit(): void {
        this.activeRoute.params.subscribe(r => {
            this.caseId = +r['caseId'];
            this.editDocument(+r['id']);
        });
    }

    public editDocument(id: number): void {
        if (!!this.fileUpload) {
            this.fileUpload.reset();
        }

        if (id > 0) {
            this.api.getDocument(this.caseId, id).subscribe(
                result => {
                    this.document = result;
                    this.formService.buildFormGroup<CaseDocument>(this.document, ObjectType.CaseDocument)
                        .subscribe((fbg: FormGroup) => {
                            this.formGroup = fbg;
                        });

                }
            );
        } else {
            this.document = new CaseDocument();
            this.formService.buildFormGroup<CaseDocument>(this.document, ObjectType.CaseDocument)
                .subscribe((fbg: FormGroup) => {
                    this.formGroup = fbg;
                });
        }
    }

    submit(value: any) {
        this.submitted = true;
        if (this.formGroup.valid) {
            this.formService.buildObject(value, this.document);
            this.document.fileName = this.fileUpload.fileName;
            if (this.document.id === 0) {
                this.api.createDocument(this.caseId, this.document).subscribe((document) => {
                    this.updateDocument(document);
                });
            } else {
                this.api.updateDocument(this.caseId, this.document.id, this.document).subscribe((document) => {
                    this.updateDocument(document);
                });
            }
        }
    }

    private updateDocument(document: CaseDocument) {
        if (this.fileUpload.fileName !== '') {
            this.api.uploadDocument(this.caseId, document.id, this.fileUpload.formData).subscribe(upload => {
                document.fileName = this.fileUpload.fileName;
                this.router.navigate([`/cases/${this.caseId}/documents`]);
            });
        } else {
            this.router.navigate([`/cases/${this.caseId}/documents`]);

        }
    }

    cancel(): void {
        this.router.navigate([`/cases/${this.caseId}/documents`]);
    }
}
