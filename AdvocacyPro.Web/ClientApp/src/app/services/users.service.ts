import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserData } from '../models/userData.model';
import { Case } from '../models/case.model';
import { Fire } from '../models/fire.model';

@Injectable({providedIn: 'root'})
export class UsersService {
    constructor(private httpService: HttpClient) { }

    getAll(): Observable<UserData[]> {
        return this.httpService.get<UserData[]>('api/Users');
    }

    get(id: number): Observable<UserData> {
        return this.httpService.get<UserData>(`api/Users/${id}`);
    }

    create(user: UserData): Observable<UserData> {
        return this.httpService.post<UserData>('api/Users', user);
    }

    delete(id: number) {
        return this.httpService.delete<UserData>(`api/Users/${id}`);
    }

    update(id: number, user: UserData) {
        return this.httpService.put<UserData>(`api/Users/${id}`, user);
    }

    getCases(id: number): Observable<Case[]> {
        return this.httpService.get<Case[]>(`api/Users/${id}/Cases`);
    }

    getFires(id: number): Observable<Fire[]> {
        return this.httpService.get<Fire[]>(`api/Users/${id}/Fires`);
    }
}
