import {
    ValueBase, OffenseType, Offense, LocationType, AgeGrouping, ContactType, DocumentType,
    ReferralType, ServiceCategory, ServicePopulation, ServiceProgram, Country, FireCause,
    Ethnicity, Gender, OrganizationType, Race, RelationshipType, State, Status, ApplicationStatus,
    BondType, DocketType, InterviewerPosition, Language, LetterType, OrderStatus, OrderType,
    PaymentCategory, Payor, VictimType, InterviewDocumentationType, ValueList
} from '../models/valueBase.model';
import { Injectable } from '@angular/core';
import { UsersService } from './users.service';
import { HttpClient } from '@angular/common/http';
import { ValueAPIEndpoints } from '../models/constants';
import { Observable, forkJoin } from 'rxjs';
import { UserData } from '../models/userData.model';
import { tap, map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class ValuesService {
    private _offenseTypes: ValueList<OffenseType>;
    private _offenses: ValueList<Offense>;
    private _locationTypes: ValueList<LocationType>;
    private _ageGroupings: ValueList<AgeGrouping>;
    private _contactTypes: ValueList<ContactType>;
    private _documentTypes: ValueList<DocumentType>;
    private _referralTypes: ValueList<ReferralType>;
    private _serviceCategories: ValueList<ServiceCategory>;
    private _servicePopulations: ValueList<ServicePopulation>;
    private _servicePrograms: ValueList<ServiceProgram>;
    private _countries: ValueList<Country>;
    private _ethnicities: ValueList<Ethnicity>;
    private _fireCauses: ValueList<FireCause>;
    private _genders: ValueList<Gender>;
    private _organizationTypes: ValueList<OrganizationType>;
    private _races: ValueList<Race>;
    private _relationshipTypes: ValueList<RelationshipType>;
    private _states: ValueList<State, string>;
    private _statuses: ValueList<Status>;
    private _applicationStatuses: ValueList<ApplicationStatus>;
    private _bondTypes: ValueList<BondType>;
    private _docketTypes: ValueList<DocketType>;
    private _interviewerPositions: ValueList<InterviewerPosition>;
    private _languages: ValueList<Language>;
    private _letterTypes: ValueList<LetterType>;
    private _orderStatuses: ValueList<OrderStatus>;
    private _orderTypes: ValueList<OrderType>;
    private _paymentCategories: ValueList<PaymentCategory>;
    private _payors: ValueList<Payor>;
    private _victimTypes: ValueList<VictimType>;
    private _interviewDocumentationTypes: ValueList<InterviewDocumentationType>;
    private _users: UserData[] = [];

    constructor(private uApi: UsersService, private httpService: HttpClient) { }

    private initializeList<T extends ValueBase, TKey>(endPoint: string, listProperty: ValueList<T, TKey>, key = 'id'): Observable<boolean> {
        return this.getAll<T>(endPoint).pipe(tap(o => { listProperty = new ValueList<T, TKey>(o, key); }), map(_ => true));
    }

    initialize(): Observable<boolean> {
        return forkJoin(
            this.initializeList(ValueAPIEndpoints.offensetypes, this._offenseTypes),
            this.initializeList(ValueAPIEndpoints.offenses, this._offenses),
            this.initializeList(ValueAPIEndpoints.locationtypes, this._locationTypes),
            this.initializeList(ValueAPIEndpoints.agegroupings, this._ageGroupings),
            this.initializeList(ValueAPIEndpoints.contacttypes, this._contactTypes),
            this.initializeList(ValueAPIEndpoints.documenttypes, this._documentTypes),
            this.initializeList(ValueAPIEndpoints.referraltypes, this._referralTypes),
            this.initializeList(ValueAPIEndpoints.servicecategories, this._serviceCategories),
            this.initializeList(ValueAPIEndpoints.servicepopulations, this._servicePopulations),
            this.initializeList(ValueAPIEndpoints.serviceprograms, this._servicePrograms),
            this.initializeList(ValueAPIEndpoints.countries, this._countries),
            this.initializeList(ValueAPIEndpoints.ethnicities, this._ethnicities),
            this.initializeList(ValueAPIEndpoints.firecauses, this._fireCauses),
            this.initializeList(ValueAPIEndpoints.genders, this._genders),
            this.initializeList(ValueAPIEndpoints.organizationtypes, this._organizationTypes),
            this.initializeList(ValueAPIEndpoints.races, this._races),
            this.initializeList(ValueAPIEndpoints.relationshiptypes, this._relationshipTypes),
            this.initializeList(ValueAPIEndpoints.states, this._states, 'code'),
            this.initializeList(ValueAPIEndpoints.statuses, this._statuses),
            this.initializeList(ValueAPIEndpoints.applicationstatuses, this._applicationStatuses),
            this.initializeList(ValueAPIEndpoints.bondtypes, this._bondTypes),
            this.initializeList(ValueAPIEndpoints.dockettypes, this._docketTypes),
            this.initializeList(ValueAPIEndpoints.interviewerpositions, this._interviewerPositions),
            this.initializeList(ValueAPIEndpoints.languages, this._languages),
            this.initializeList(ValueAPIEndpoints.lettertypes, this._letterTypes),
            this.initializeList(ValueAPIEndpoints.orderstatuses, this._orderStatuses),
            this.initializeList(ValueAPIEndpoints.ordertypes, this._orderTypes),
            this.initializeList(ValueAPIEndpoints.paymentcategories, this._paymentCategories),
            this.initializeList(ValueAPIEndpoints.payors, this._payors),
            this.initializeList(ValueAPIEndpoints.victimtypes, this._victimTypes),
            this.initializeList(ValueAPIEndpoints.interviewdocumentationtypes, this._interviewDocumentationTypes),
            this.uApi.getAll().pipe(tap(o => {
                this._users = o.sort((a, b) => a.firstName + ' ' + a.lastName < b.firstName + ' ' + b.lastName ? -1 : 1);
            }))
        ).pipe(map(_ => true));
    }

    public get offenseTypes(): ValueList<OffenseType> { return this._offenseTypes; }
    public get offenses(): ValueList<Offense> { return this._offenses; }
    public get locationTypes(): ValueList<LocationType> { return this._locationTypes; }
    public get ageGroupings(): ValueList<AgeGrouping> { return this._ageGroupings; }
    public get caseContactTypes(): ValueList<ContactType> { return this._contactTypes; }
    public get caseDocumentTypes(): ValueList<DocumentType> { return this._documentTypes; }
    public get caseReferralTypes(): ValueList<ReferralType> { return this._referralTypes; }
    public get caseServiceCategories(): ValueList<ServiceCategory> { return this._serviceCategories; }
    public get caseServicePopulations(): ValueList<ServicePopulation> { return this._servicePopulations; }
    public get caseServicePrograms(): ValueList<ServiceProgram> { return this._servicePrograms; }
    public get countries(): ValueList<Country> { return this._countries; }
    public get ethnicities(): ValueList<Ethnicity> { return this._ethnicities; }
    public get fireCauses(): ValueList<FireCause> { return this._fireCauses; }
    public get genders(): ValueList<Gender> { return this._genders; }
    public get orgTypes(): ValueList<OrganizationType> { return this._organizationTypes; }
    public get races(): ValueList<Race> { return this._races; }
    public get relationshipTypes(): ValueList<RelationshipType> { return this._relationshipTypes; }
    public get states(): ValueList<State, string> { return this._states; }
    public get statuses(): ValueList<Status> { return this._statuses; }
    public get applicationStatuses(): ValueList<ApplicationStatus> { return this._applicationStatuses; }
    public get bondTypes(): ValueList<BondType> { return this._bondTypes; }
    public get docketTypes(): ValueList<DocketType> { return this._docketTypes; }
    public get interviewerPositions(): ValueList<InterviewerPosition> { return this._interviewerPositions; }
    public get languages(): ValueList<Language> { return this._languages; }
    public get letterTypes(): ValueList<LetterType> { return this._letterTypes; }
    public get orderStatuses(): ValueList<OrderStatus> { return this._orderStatuses; }
    public get orderTypes(): ValueList<OrderType> { return this._orderTypes; }
    public get paymentCategories(): ValueList<PaymentCategory> { return this._paymentCategories; }
    public get payors(): ValueList<Payor> { return this._payors; }
    public get victimTypes(): ValueList<VictimType> { return this._victimTypes; }
    public get interviewDocumentationTypes(): ValueList<InterviewDocumentationType> { return this._interviewDocumentationTypes; }
    public get users(): Array<UserData> { return this._users; }

    getAll<T>(apiEndpoint: string): Observable<T[]> {
        return this.httpService.get<T[]>(apiEndpoint);
    }
    get<T>(apiEndpoint: string, id: number): Observable<T> {
        return this.httpService.get<T>(`${apiEndpoint}/${id}`);
    }
    create<T>(apiEndpoint: string, T: T): Observable<T> {
        return this.httpService.post<T>(apiEndpoint, T);
    }
    delete<T>(apiEndpoint: string, id: number) {
        return this.httpService.delete<T>(`${apiEndpoint}/${id}`);
    }
    update<T>(apiEndpoint: string, id: number, T: T) {
        return this.httpService.put<T>(`${apiEndpoint}/${id}`, T);
    }
}
