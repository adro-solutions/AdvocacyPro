import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Feature } from '../models/feature.model';

@Injectable({providedIn: 'root'})
export class FeaturesService {
    constructor(private httpService: HttpClient) { }

    getAll(): Observable<Feature[]> {
        return this.httpService.get<Feature[]>('api/Features');
    }
}
