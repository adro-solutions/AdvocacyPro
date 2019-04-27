import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ZipCode } from '../models/zipCode.model';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class ZipCodesService {
    constructor(private httpService: HttpClient) { }

    get(zipCode: string): Observable<ZipCode> {
        return this.httpService.get<ZipCode>(`api/ZipCodes/${zipCode}`);
    }
}
