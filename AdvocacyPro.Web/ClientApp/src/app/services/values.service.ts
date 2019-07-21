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
import { Observable, forkJoin, of } from 'rxjs';
import { UserData } from '../models/userData.model';
import { tap, map, switchMap } from 'rxjs/operators';
import { ObjectVersion } from '../models/objectVersion.model';

@Injectable({ providedIn: 'root' })
export class ValuesService {
    private _versions: ObjectVersion[];

    private _offenseTypes = new ValueList<OffenseType>();
    private _offenses = new ValueList<Offense>();
    private _locationTypes = new ValueList<LocationType>();
    private _ageGroupings = new ValueList<AgeGrouping>();
    private _contactTypes = new ValueList<ContactType>();
    private _documentTypes = new ValueList<DocumentType>();
    private _referralTypes = new ValueList<ReferralType>();
    private _serviceCategories = new ValueList<ServiceCategory>();
    private _servicePopulations = new ValueList<ServicePopulation>();
    private _servicePrograms = new ValueList<ServiceProgram>();
    private _countries = new ValueList<Country>();
    private _ethnicities = new ValueList<Ethnicity>();
    private _fireCauses = new ValueList<FireCause>();
    private _genders = new ValueList<Gender>();
    private _organizationTypes = new ValueList<OrganizationType>();
    private _races = new ValueList<Race>();
    private _relationshipTypes = new ValueList<RelationshipType>();
    private _states = new ValueList<State, string>('code');
    private _statuses = new ValueList<Status>();
    private _applicationStatuses = new ValueList<ApplicationStatus>();
    private _bondTypes = new ValueList<BondType>();
    private _docketTypes = new ValueList<DocketType>();
    private _interviewerPositions = new ValueList<InterviewerPosition>();
    private _languages = new ValueList<Language>();
    private _letterTypes = new ValueList<LetterType>();
    private _orderStatuses = new ValueList<OrderStatus>();
    private _orderTypes = new ValueList<OrderType>();
    private _paymentCategories = new ValueList<PaymentCategory>();
    private _payors = new ValueList<Payor>();
    private _victimTypes = new ValueList<VictimType>();
    private _interviewDocumentationTypes = new ValueList<InterviewDocumentationType>();
    private _users: UserData[] = [];

    constructor(private uApi: UsersService, private httpService: HttpClient) { }

    private initializeList<T extends ValueBase, TKey>(type: string, endPoint: string,
        listProperty: ValueList<T, TKey>): Observable<boolean> {
        const storedValue = localStorage.getItem(endPoint);
        const storedVersion = localStorage.getItem(`${endPoint}.Version`);
        const ver = this._versions.filter(v => v.type === `AdvocacyPro.Models.Values.${type}`);

        const serverVersion = ver.length === 0 ? 0 : ver[0].version;
        const localVersion = storedVersion ? +storedVersion : 0;

        if (storedValue && serverVersion === localVersion) {
            listProperty.load(JSON.parse(storedValue));
            return of(true);
        }
        return this.getAll<T>(endPoint).pipe(
            tap(o => { listProperty.load(o); }),
            tap(o => { localStorage.setItem(endPoint, JSON.stringify(o));
                       localStorage.setItem(`${endPoint}.Version`, serverVersion.toString()); }),
            map(_ => true));
    }

    initialize(): Observable<boolean> {
        return this.httpService.get<ObjectVersion[]>(`api/Object/Versions`).pipe(
            tap(v => this._versions = v),
            switchMap(v => forkJoin(
                this.initializeList('OffenseType', ValueAPIEndpoints.offensetypes, this._offenseTypes),
                this.initializeList('Offense', ValueAPIEndpoints.offenses, this._offenses),
                this.initializeList('LocationType', ValueAPIEndpoints.locationtypes, this._locationTypes),
                this.initializeList('AgeGrouping', ValueAPIEndpoints.agegroupings, this._ageGroupings),
                this.initializeList('CaseContactType', ValueAPIEndpoints.contacttypes, this._contactTypes),
                this.initializeList('CaseDocumentType', ValueAPIEndpoints.documenttypes, this._documentTypes),
                this.initializeList('CaseReferralType', ValueAPIEndpoints.referraltypes, this._referralTypes),
                this.initializeList('CaseServiceCategory', ValueAPIEndpoints.servicecategories, this._serviceCategories),
                this.initializeList('CaseServicePopulation', ValueAPIEndpoints.servicepopulations, this._servicePopulations),
                this.initializeList('CaseServiceProgram', ValueAPIEndpoints.serviceprograms, this._servicePrograms),
                this.initializeList('Country', ValueAPIEndpoints.countries, this._countries),
                this.initializeList('Ethnicity', ValueAPIEndpoints.ethnicities, this._ethnicities),
                this.initializeList('FireCause', ValueAPIEndpoints.firecauses, this._fireCauses),
                this.initializeList('Gender', ValueAPIEndpoints.genders, this._genders),
                this.initializeList('OrganizationType', ValueAPIEndpoints.organizationtypes, this._organizationTypes),
                this.initializeList('Race', ValueAPIEndpoints.races, this._races),
                this.initializeList('RelationshipType', ValueAPIEndpoints.relationshiptypes, this._relationshipTypes),
                this.initializeList('State', ValueAPIEndpoints.states, this._states),
                this.initializeList('Status', ValueAPIEndpoints.statuses, this._statuses),
                this.initializeList('ApplicationStatus', ValueAPIEndpoints.applicationstatuses, this._applicationStatuses),
                this.initializeList('BondType', ValueAPIEndpoints.bondtypes, this._bondTypes),
                this.initializeList('DocketType', ValueAPIEndpoints.dockettypes, this._docketTypes),
                this.initializeList('InterviewerPosition', ValueAPIEndpoints.interviewerpositions, this._interviewerPositions),
                this.initializeList('Language', ValueAPIEndpoints.languages, this._languages),
                this.initializeList('LetterType', ValueAPIEndpoints.lettertypes, this._letterTypes),
                this.initializeList('OrderStatus', ValueAPIEndpoints.orderstatuses, this._orderStatuses),
                this.initializeList('OrderType', ValueAPIEndpoints.ordertypes, this._orderTypes),
                this.initializeList('PaymentCategory', ValueAPIEndpoints.paymentcategories, this._paymentCategories),
                this.initializeList('Payor', ValueAPIEndpoints.payors, this._payors),
                this.initializeList('VictimType', ValueAPIEndpoints.victimtypes, this._victimTypes),
                this.initializeList('InterviewDocumentationType', ValueAPIEndpoints.interviewdocumentationtypes,
                    this._interviewDocumentationTypes),
                this.uApi.getAll().pipe(tap(o => {
                    this._users = o.sort((a, b) => a.firstName + ' ' + a.lastName < b.firstName + ' ' + b.lastName ? -1 : 1);
                }))
            ).pipe(map(_ => true)))
        );
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
    public get users(): Array<UserData> { return this._users ? this._users : []; }
    public user(id: number): UserData {
        return this.users.filter(o => o.id === id)[0];
    }
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
