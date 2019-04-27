import {
    ValueBase, OffenseType, Offense, LocationType, AgeGrouping, ContactType, DocumentType,
    ReferralType, ServiceCategory, ServicePopulation, ServiceProgram, Country, FireCause,
    Ethnicity, Gender, OrganizationType, Race, RelationshipType, State, Status, ApplicationStatus,
    BondType, DocketType, InterviewerPosition, Language, LetterType, OrderStatus, OrderType,
    PaymentCategory, Payor, VictimType, InterviewDocumentationType
} from '../models/valueBase.model';
import { Injectable } from '@angular/core';
import { UsersService } from './users.service';
import { HttpClient } from '@angular/common/http';
import { ValueAPIEndpoints } from '../models/constants';
import { Observable } from 'rxjs';
import { UserData } from '../models/userData.model';

@Injectable({ providedIn: 'root' })
export class ValuesService {
    private _offenseTypes: OffenseType[] = [];
    private _offenses: Offense[] = [];
    private _locationTypes: LocationType[] = [];
    private _ageGroupings: AgeGrouping[] = [];
    private _contactTypes: ContactType[] = [];
    private _documentTypes: DocumentType[] = [];
    private _referralTypes: ReferralType[] = [];
    private _serviceCategories: ServiceCategory[] = [];
    private _servicePopulations: ServicePopulation[] = [];
    private _servicePrograms: ServiceProgram[] = [];
    private _countries: Country[] = [];
    private _ethnicities: Ethnicity[] = [];
    private _fireCauses: FireCause[] = [];
    private _genders: Gender[] = [];
    private _organizationTypes: OrganizationType[] = [];
    private _races: Race[] = [];
    private _relationshipTypes: RelationshipType[] = [];
    private _states: State[] = [];
    private _statuses: Status[] = [];
    private _applicationStatuses: ApplicationStatus[] = [];
    private _bondTypes: BondType[] = [];
    private _docketTypes: DocketType[] = [];
    private _interviewerPositions: InterviewerPosition[] = [];
    private _languages: Language[] = [];
    private _letterTypes: LetterType[] = [];
    private _orderStatuses: OrderStatus[] = [];
    private _orderTypes: OrderType[] = [];
    private _paymentCategories: PaymentCategory[] = [];
    private _payors: Payor[] = [];
    private _victimTypes: VictimType[] = [];
    private _interviewDocumentationTypes: InterviewDocumentationType[] = [];
    private _users: UserData[] = [];
    constructor(private uApi: UsersService, private httpService: HttpClient) { }

    private sortValueBase<T extends ValueBase>(list: T[]): T[] {
        return list.sort((a, b) => a.name < b.name ? -1 : 1);
    }

    initialize() {
        this.getAll<OffenseType>(ValueAPIEndpoints.offensetypes).subscribe(o => { this._offenseTypes = this.sortValueBase(o); });
        this.getAll<Offense>(ValueAPIEndpoints.offenses).subscribe(o => { this._offenses = this.sortValueBase(o); });
        this.getAll<LocationType>(ValueAPIEndpoints.locationtypes).subscribe(o => { this._locationTypes = this.sortValueBase(o); });
        this.getAll<AgeGrouping>(ValueAPIEndpoints.agegroupings).subscribe(o => { this._ageGroupings = this.sortValueBase(o); });
        this.getAll<ContactType>(ValueAPIEndpoints.contacttypes).subscribe(o => { this._contactTypes = this.sortValueBase(o); });
        this.getAll<DocumentType>(ValueAPIEndpoints.documenttypes).subscribe(o => { this._documentTypes = this.sortValueBase(o); });
        this.getAll<ReferralType>(ValueAPIEndpoints.referraltypes).subscribe(o => { this._referralTypes = this.sortValueBase(o); });
        this.getAll<ServiceCategory>(ValueAPIEndpoints.servicecategories).subscribe(o => {
            this._serviceCategories = this.sortValueBase(o);
        });
        this.getAll<ServicePopulation>(ValueAPIEndpoints.servicepopulations).subscribe(o => {
            this._servicePopulations = this.sortValueBase(o);
        });
        this.getAll<ServiceProgram>(ValueAPIEndpoints.serviceprograms).subscribe(o => { this._servicePrograms = this.sortValueBase(o); });
        this.getAll<Country>(ValueAPIEndpoints.countries).subscribe(o => { this._countries = this.sortValueBase(o); });
        this.getAll<Ethnicity>(ValueAPIEndpoints.ethnicities).subscribe(o => { this._ethnicities = this.sortValueBase(o); });
        this.getAll<FireCause>(ValueAPIEndpoints.firecauses).subscribe(o => { this._fireCauses = this.sortValueBase(o); });
        this.getAll<Gender>(ValueAPIEndpoints.genders).subscribe(o => { this._genders = this.sortValueBase(o); });
        this.getAll<OrganizationType>(ValueAPIEndpoints.organizationtypes).subscribe(o => {
            this._organizationTypes = this.sortValueBase(o);
        });
        this.getAll<Race>(ValueAPIEndpoints.races).subscribe(o => { this._races = this.sortValueBase(o); });
        this.getAll<RelationshipType>(ValueAPIEndpoints.relationshiptypes).subscribe(o => {
            this._relationshipTypes = this.sortValueBase(o);
        });
        this.getAll<State>(ValueAPIEndpoints.states).subscribe(o => { this._states = this.sortValueBase(o); });
        this.getAll<Status>(ValueAPIEndpoints.statuses).subscribe(o => { this._statuses = this.sortValueBase(o); });
        this.getAll<ApplicationStatus>(ValueAPIEndpoints.applicationstatuses).subscribe(o => {
            this._applicationStatuses = this.sortValueBase(o);
        });
        this.getAll<BondType>(ValueAPIEndpoints.bondtypes).subscribe(o => { this._bondTypes = this.sortValueBase(o); });
        this.getAll<DocketType>(ValueAPIEndpoints.dockettypes).subscribe(o => { this._docketTypes = this.sortValueBase(o); });
        this.getAll<InterviewerPosition>(ValueAPIEndpoints.interviewerpositions).subscribe(o => {
            this._interviewerPositions = this.sortValueBase(o);
        });
        this.getAll<Language>(ValueAPIEndpoints.languages).subscribe(o => { this._languages = this.sortValueBase(o); });
        this.getAll<LetterType>(ValueAPIEndpoints.lettertypes).subscribe(o => { this._letterTypes = this.sortValueBase(o); });
        this.getAll<OrderStatus>(ValueAPIEndpoints.orderstatuses).subscribe(o => { this._orderStatuses = this.sortValueBase(o); });
        this.getAll<OrderType>(ValueAPIEndpoints.ordertypes).subscribe(o => { this._orderTypes = this.sortValueBase(o); });
        this.getAll<PaymentCategory>(ValueAPIEndpoints.paymentcategories).subscribe(o => {
            this._paymentCategories = this.sortValueBase(o);
        });
        this.getAll<Payor>(ValueAPIEndpoints.payors).subscribe(o => { this._payors = this.sortValueBase(o); });
        this.getAll<VictimType>(ValueAPIEndpoints.victimtypes).subscribe(o => { this._victimTypes = this.sortValueBase(o); });
        this.getAll<InterviewDocumentationType>(ValueAPIEndpoints.interviewdocumentationtypes).subscribe(o => {
            this._interviewDocumentationTypes = this.sortValueBase(o);
        });

        this.uApi.getAll().subscribe(o => {
            this._users = o.sort((a, b) => a.firstName + ' ' + a.lastName < b.firstName + ' ' + b.lastName ? -1 : 1);
        });
    }

    public get offenseTypes(): Array<OffenseType> {
        return this._offenseTypes;
    }
    public offenseType(id: number): OffenseType {
        return this.offenseTypes.filter(o => o.id === id)[0];
    }

    public get offenses(): Array<Offense> {
        return this._offenses;
    }
    public offense(id: number): Offense {
        return this.offenses.filter(o => o.id === id)[0];
    }

    public get locationTypes(): Array<LocationType> {
        return this._locationTypes;
    }
    public locationType(id: number): LocationType {
        return this.locationTypes.filter(o => o.id === id)[0];
    }

    public get ageGroupings(): Array<AgeGrouping> {
        return this._ageGroupings;
    }
    public ageGrouping(id: number): AgeGrouping {
        return this.ageGroupings.filter(o => o.id === id)[0];
    }

    public get caseContactTypes(): Array<ContactType> {
        return this._contactTypes;
    }
    public caseContactType(id: number): ContactType {
        return this.caseContactTypes.filter(o => o.id === id)[0];
    }

    public get caseDocumentTypes(): Array<DocumentType> {
        return this._documentTypes;
    }
    public caseDocumentType(id: number): DocumentType {
        return this.caseDocumentTypes.filter(o => o.id === id)[0];
    }

    public get caseReferralTypes(): Array<ReferralType> {
        return this._referralTypes;
    }
    public caseReferralType(id: number): ReferralType {
        return this.caseReferralTypes.filter(o => o.id === id)[0];
    }

    public get caseServiceCategories(): Array<ServiceCategory> {
        return this._serviceCategories;
    }
    public caseServiceCategory(id: number): ServiceCategory {
        return this.caseServiceCategories.filter(o => o.id === id)[0];
    }

    public get caseServicePopulations(): Array<ServicePopulation> {
        return this._servicePopulations;
    }
    public caseServicePopulation(id: number): ServicePopulation {
        return this.caseServicePopulations.filter(o => o.id === id)[0];
    }

    public get caseServicePrograms(): Array<ServiceProgram> {
        return this._servicePrograms;
    }
    public caseServiceProgram(id: number): ServiceProgram {
        return this.caseServicePrograms.filter(o => o.id === id)[0];
    }

    public get countries(): Array<Country> {
        return this._countries;
    }
    public country(id: number): Country {
        return this.countries.filter(o => o.id === id)[0];
    }

    public get ethnicities(): Array<Ethnicity> {
        return this._ethnicities;
    }
    public ethnicity(id: number): Ethnicity {
        return this.ethnicities.filter(o => o.id === id)[0];
    }

    public get fireCauses(): Array<FireCause> {
        return this._fireCauses;
    }
    public fireCause(id: number): FireCause {
        return this.fireCauses.filter(o => o.id === id)[0];
    }

    public get genders(): Array<Gender> {
        return this._genders;
    }
    public gender(id: number): Gender {
        return this.genders.filter(o => o.id === id)[0];
    }

    public get orgTypes(): Array<OrganizationType> {
        return this._organizationTypes;
    }
    public orgType(id: number): OrganizationType {
        return this.orgTypes.filter(o => o.id === id)[0];
    }

    public get races(): Array<Race> {
        return this._races;
    }
    public race(id: number): Race {
        return this.races.filter(o => o.id === id)[0];
    }

    public get relationshipTypes(): Array<RelationshipType> {
        return this._relationshipTypes;
    }
    public relationshipType(id: number): RelationshipType {
        return this.relationshipTypes.filter(o => o.id === id)[0];
    }

    public get states(): Array<State> {
        return this._states;
    }
    public state(code: string): State {
        return this.states.filter(o => o.code === code)[0];
    }

    public get statuses(): Array<Status> {
        return this._statuses;
    }
    public status(id: number): Status {
        return this.statuses.filter(o => o.id === id)[0];
    }

    public get users(): Array<UserData> {
        return this._users;
    }
    public user(id: number): UserData {
        return this.users.filter(o => o.id === id)[0];
    }

    public get applicationStatuses(): Array<ApplicationStatus> {
        return this._applicationStatuses;
    }
    public applicationStatus(id: number): ApplicationStatus {
        return this.applicationStatuses.filter(o => o.id === id)[0];
    }

    public get bondTypes(): Array<BondType> {
        return this._bondTypes;
    }
    public bondType(id: number): BondType {
        return this.bondTypes.filter(o => o.id === id)[0];
    }

    public get docketTypes(): Array<DocketType> {
        return this._docketTypes;
    }
    public docketType(id: number): DocketType {
        return this.docketTypes.filter(o => o.id === id)[0];
    }

    public get interviewerPositions(): Array<InterviewerPosition> {
        return this._interviewerPositions;
    }
    public interviewerPosition(id: number): InterviewerPosition {
        return this.interviewerPositions.filter(o => o.id === id)[0];
    }

    public get languages(): Array<Language> {
        return this._languages;
    }
    public language(id: number): Language {
        return this.languages.filter(o => o.id === id)[0];
    }

    public get letterTypes(): Array<LetterType> {
        return this._letterTypes;
    }
    public letterType(id: number): LetterType {
        return this.letterTypes.filter(o => o.id === id)[0];
    }

    public get orderStatuses(): Array<OrderStatus> {
        return this._orderStatuses;
    }
    public orderStatus(id: number): OrderStatus {
        return this.orderStatuses.filter(o => o.id === id)[0];
    }

    public get orderTypes(): Array<OrderType> {
        return this._orderTypes;
    }
    public orderType(id: number): OrderType {
        return this.orderTypes.filter(o => o.id === id)[0];
    }

    public get paymentCategories(): Array<PaymentCategory> {
        return this._paymentCategories;
    }
    public paymentCategory(id: number): PaymentCategory {
        return this.paymentCategories.filter(o => o.id === id)[0];
    }

    public get payors(): Array<Payor> {
        return this._payors;
    }
    public payor(id: number): Payor {
        return this.payors.filter(o => o.id === id)[0];
    }

    public get victimTypes(): Array<VictimType> {
        return this._victimTypes;
    }
    public victimType(id: number): VictimType {
        return this.victimTypes.filter(o => o.id === id)[0];
    }

    public get interviewDocumentationTypes(): Array<InterviewDocumentationType> {
        return this._interviewDocumentationTypes;
    }
    public interviewDocumentationType(id: number): InterviewDocumentationType {
        return this.interviewDocumentationTypes.filter(o => o.id === id)[0];
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
