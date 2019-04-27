import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Organization } from '../models/valueBase.model';
import { User } from '../models/user.model';
import { Feature } from '../models/feature.model';

@Injectable({providedIn: 'root'})
export class OrganizationsService {
    constructor(private httpService: HttpClient) { }

    getAll(): Observable<Organization[]> {
        return this.httpService.get<Organization[]>('api/Organizations');
    }

    get(id: number): Observable<Organization> {
        return this.httpService.get<Organization>(`api/Organizations/${id}`);
    }

    create(organization: Organization): Observable<Organization> {
        return this.httpService.post<Organization>('api/Organizations', organization);
    }

    delete(id: number) {
        return this.httpService.delete<Organization>(`api/Organizations/${id}`);
    }

    update(id: number, organization: Organization) {
        return this.httpService.put<Organization>(`api/Organizations/${id}`, organization);
    }

    getUsers(orgId: number): Observable<User[]> {
        return this.httpService.get<User[]>(`api/Organizations/${orgId}/users`);
    }

    getUser(orgId: number, userId: number): Observable<User> {
        return this.httpService.get<User>(`api/Organizations/${orgId}/users/${userId}`);
    }

    createUser(orgId: number, user: User) {
        return this.httpService.post<User>(`api/Organizations/${orgId}/users/`, user);
    }

    updateUser(orgId: number, userId: number, user: User) {
        return this.httpService.put<User>(`api/Organizations/${orgId}/users/${userId}`, user);
    }

    deleteUser(orgId: number, userId: number) {
        return this.httpService.delete<User>(`api/Organizations/${orgId}/users/${userId}`);
    }

    uploadLogo(orgId: number, formData: FormData): Observable<Organization> {
        return this.httpService.post<Organization>(`api/Organizations/${orgId}/logo`, formData);
    }

    getUserFeatures(orgId: number, userId: number): Observable<Feature[]> {
        return this.httpService.get<Feature[]>(`api/Organizations/${orgId}/users/${userId}/features`);
    }

    updateUserFeatures(orgId: number, userId: number, features: Feature[]) {
        return this.httpService.post(`api/Organizations/${orgId}/users/${userId}/features`, features);
    }

    getFeatures(orgId: number): Observable<Feature[]> {
        return this.httpService.get<Feature[]>(`api/Organizations/${orgId}/features`);
    }

    updateFeatures(orgId: number, features: Feature[]) {
        return this.httpService.post(`api/Organizations/${orgId}/features`, features);
    }
}
