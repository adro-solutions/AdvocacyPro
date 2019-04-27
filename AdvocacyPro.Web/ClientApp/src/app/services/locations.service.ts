import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable( {providedIn: 'root'})
export class LocationsService {
    constructor(private httpService: HttpClient) { }

    getAll(): Observable<string[]> {
        return this.httpService.get<string[]>('api/Locations');
    }
}
