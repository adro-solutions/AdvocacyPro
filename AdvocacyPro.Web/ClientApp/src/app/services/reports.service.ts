import * as moment from 'moment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CaseIncident } from '../models/caseIncident.model';
import { Fire } from '../models/fire.model';
import { Case } from '../models/case.model';
import { CaseService } from '../models/caseService.model';
import { CaseVictimization } from '../models/caseVictimization.model';

@Injectable({providedIn: 'root'})
export class ReportsService {
    constructor(private httpService: HttpClient) { }

    getCrimeData(startDate: Date, endDate: Date): Observable<CaseIncident[]> {
        const s: string = moment(startDate).utc().format('MM/DD/YYYY');
        const e: string = moment(endDate).utc().format('MM/DD/YYYY');
        return this.httpService.get<CaseIncident[]>(`api/Reports/CrimeData?startDate=${s}&endDate=${e}`);
    }

    getFireData(startDate: Date, endDate: Date): Observable<Fire[]> {
        const s: string = moment(startDate).utc().format('MM/DD/YYYY');
        const e: string = moment(endDate).utc().format('MM/DD/YYYY');
        return this.httpService.get<Fire[]>(`api/Reports/FireData?startDate=${s}&endDate=${e}`);
    }

    getCaseData(startDate: Date, endDate: Date): Observable<Case[]> {
        const s: string = moment(startDate).utc().format('MM/DD/YYYY');
        const e: string = moment(endDate).utc().format('MM/DD/YYYY');
        return this.httpService.get<Case[]>(`api/Reports/CaseData?startDate=${s}&endDate=${e}`);
    }

    getServiceData(startDate: Date, endDate: Date): Observable<CaseService[]> {
        const s: string = moment(startDate).utc().format('MM/DD/YYYY');
        const e: string = moment(endDate).utc().format('MM/DD/YYYY');
        return this.httpService.get<CaseService[]>(`api/Reports/ServiceData?startDate=${s}&endDate=${e}`);
    }

    getVictimizationData(startDate: Date, endDate: Date): Observable<CaseVictimization[]> {
        const s: string = moment(startDate).utc().format('MM/DD/YYYY');
        const e: string = moment(endDate).utc().format('MM/DD/YYYY');
        return this.httpService.get<CaseVictimization[]>(`api/Reports/VictimizationData?startDate=${s}&endDate=${e}`);
    }
}
