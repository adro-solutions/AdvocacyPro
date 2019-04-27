import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Fire } from '../models/fire.model';

@Injectable({ providedIn: 'root' })
export class FiresService {
    constructor(private httpService: HttpClient) { }

    getAll(archived: boolean): Observable<Fire[]> {
        if (archived) {
            return this.httpService.get<Fire[]>('api/Fires/Archived');
        } else {
            return this.httpService.get<Fire[]>('api/Fires');
        }
    }

    get(id: number): Observable<Fire> {
        return this.httpService.get<Fire>(`api/Fires/${id}`);
    }

    create(fire: Fire): Observable<Fire> {
        return this.httpService.post<Fire>('api/Fires', fire);
    }

    update(id: number, fire: Fire) {
        return this.httpService.put<Fire>(`api/Fires/${id}`, fire);
    }
}
