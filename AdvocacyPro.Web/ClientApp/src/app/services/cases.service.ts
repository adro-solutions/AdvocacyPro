import * as FileSaver from 'file-saver';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Case } from '../models/case.model';
import { CaseDocument } from '../models/caseDocument.model';

@Injectable({providedIn: 'root'})
export class CasesService {
    constructor(private httpService: HttpClient) { }

    getAll(archived: boolean): Observable<Case[]> {
        if (archived) {
            return this.httpService.get<Case[]>('api/Cases/Archived');
        } else {
            return this.httpService.get<Case[]>('api/Cases');
        }
    }

    get(id: number): Observable<Case> {
        return this.httpService.get<Case>(`api/Cases/${id}`);
    }

    create(c: Case): Observable<Case> {
        return this.httpService.post<Case>('api/Cases', c);
    }

    update(id: number, c: Case): Observable<Case> {
        return this.httpService.put<Case>(`api/Cases/${id}`, c);
    }

    // BaseComponent
    getItems<T>(caseId: number, caseEndpoint: string): Observable<T[]> {
        return this.httpService.get<T[]>(`api/Cases/${caseId}/${caseEndpoint}`);
    }
    getItem<T>(caseId: number, id: number, caseEndpoint: string): Observable<T> {
        return this.httpService.get<T>(`api/Cases/${caseId}/${caseEndpoint}/${id}`);
    }
    createItem<T>(caseId: number, item: T, caseEndpoint: string): Observable<T> {
        return this.httpService.post<T>(`api/Cases/${caseId}/${caseEndpoint}`, item);
    }
    updateItem<T>(caseId: number, id: number, item: T, caseEndpoint: string): Observable<T> {
        return this.httpService.put<T>(`api/Cases/${caseId}/${caseEndpoint}/${id}`, item);
    }
    deleteItem<T>(caseId: number, id: number, caseEndpoint: string): Observable<T> {
        return this.httpService.delete<T>(`api/Cases/${caseId}/${caseEndpoint}/${id}`);
    }

    // Documents
    getDocument(caseId: number, id: number): Observable<CaseDocument> {
        return this.httpService.get<CaseDocument>(`api/Cases/${caseId}/documents/${id}`);
    }
    createDocument(caseId: number, document: CaseDocument): Observable<CaseDocument> {
        return this.httpService.post<CaseDocument>(`api/Cases/${caseId}/documents`, document);
    }
    updateDocument(caseId: number, id: number, document: CaseDocument): Observable<CaseDocument> {
        return this.httpService.put<CaseDocument>(`api/Cases/${caseId}/documents/${id}`, document);
    }
    downloadDocument(caseId: number, id: number, fileName: string) {
        const headers = new HttpHeaders().append('responseType', 'blob');
        this.httpService.get(`api/Cases/${caseId}/documents/${id}/file`, { headers }).subscribe(data => {
            FileSaver.saveAs(data, fileName);
        });
    }
    uploadDocument(caseId: number, id: number, formData: FormData): Observable<FormData> {
        return this.httpService.post<FormData>(`api/Cases/${caseId}/documents/${id}/file`, formData);
    }
}
