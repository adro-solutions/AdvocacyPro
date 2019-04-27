import { Injectable, Observable, Router } from '../vendor';
import * as m from '../models';
import * as s from '../services';
import { ValueBase } from '../models/valueBase.model'
import { ObjectVersion, ValueAPIEndpoints } from '../models';


@Injectable()
export class ValuesService {
    constructor(private uApi: s.UsersService, private httpService: s.HttpService) {
    }

    private sortValueBase(list: ValueBase[]) {
        return list.sort((a, b) => a.name < b.name ? -1 : 1);
    }

    private checkForNewVersion(versions: ObjectVersion[], type: string): boolean {
        var ver = versions.filter(ver => ver.type == type);
        var serverVersion = ver.length == 0 ? 0 : ver[0].version;
        var localVersion = localStorage.getItem(`${type}.Version`);
        if (localVersion == null || serverVersion != +localVersion) {
            localStorage.setItem(`${type}.Version`, serverVersion.toString());
            return true;
        }
        return false;
    }

    initialize() {
        this.httpService.get<ObjectVersion[]>(`api/Object/Versions`).subscribe(v => {
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.OffenseType"))
                this.getAll<m.OffenseType>(ValueAPIEndpoints.offensetypes).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_offenseTypes", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.Offense"))
                this.getAll<m.Offense>(ValueAPIEndpoints.offenses).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_offenses", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.LocationType"))
                this.getAll<m.LocationType>(ValueAPIEndpoints.locationtypes).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_locationTypes", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.AgeGrouping"))
                this.getAll<m.AgeGrouping>(ValueAPIEndpoints.agegroupings).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_ageGroupings", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.CaseContactType"))
                this.getAll<m.ContactType>(ValueAPIEndpoints.contacttypes).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_caseContactTypes", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.CaseDocumentType"))
                this.getAll<m.DocumentType>(ValueAPIEndpoints.documenttypes).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_caseDocumentTypes", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.CaseReferralType"))
                this.getAll<m.ReferralType>(ValueAPIEndpoints.referraltypes).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_caseReferralTypes", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.CaseServiceCategory"))
                this.getAll<m.ServiceCategory>(ValueAPIEndpoints.servicecategories).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_caseServiceCategories", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.CaseServicePopulation"))
                this.getAll<m.ServicePopulation>(ValueAPIEndpoints.servicepopulations).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_caseServicePopulations", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.CaseServiceProgram"))
                this.getAll<m.ServiceProgram>(ValueAPIEndpoints.serviceprograms).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_caseServicePrograms", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.Country"))
                this.getAll<m.Country>(ValueAPIEndpoints.countries).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_countries", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.Ethnicity"))
                this.getAll<m.Ethnicity>(ValueAPIEndpoints.ethnicities).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_ethnicities", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.FireCause"))
                this.getAll<m.FireCause>(ValueAPIEndpoints.firecauses).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_fireCauses", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.Gender"))
                this.getAll<m.Gender>(ValueAPIEndpoints.genders).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_genders", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.OrganizationType"))
                this.getAll<m.OrganizationType>(ValueAPIEndpoints.organizationtypes).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_orgTypes", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.Race"))
                this.getAll<m.Race>(ValueAPIEndpoints.races).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_races", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.RelationshipType"))
                this.getAll<m.RelationshipType>(ValueAPIEndpoints.relationshiptypes).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_relationshipTypes", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.State"))
                this.getAll<m.State>(ValueAPIEndpoints.states).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_states", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.Status"))
                this.getAll<m.Status>(ValueAPIEndpoints.statuses).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_statuses", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.ApplicationStatus"))
                this.getAll<m.ApplicationStatus>(ValueAPIEndpoints.applicationstatuses).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_applicationStatuses", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.BondType"))
                this.getAll<m.BondType>(ValueAPIEndpoints.bondtypes).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_bondTypes", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.DocketType"))
                this.getAll<m.DocketType>(ValueAPIEndpoints.dockettypes).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_docketTypes", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.InterviewerPosition"))
                this.getAll<m.InterviewerPosition>(ValueAPIEndpoints.interviewerpositions).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_interviewerPositions", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.Language"))
                this.getAll<m.Language>(ValueAPIEndpoints.languages).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_languages", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.LetterType"))
                this.getAll<m.LetterType>(ValueAPIEndpoints.lettertypes).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_letterTypes", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.OrderStatus"))
                this.getAll<m.OrderStatus>(ValueAPIEndpoints.orderstatuses).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_orderStatuses", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.OrderType"))
                this.getAll<m.OrderType>(ValueAPIEndpoints.ordertypes).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_orderTypes", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.PaymentCategory"))
                this.getAll<m.PaymentCategory>(ValueAPIEndpoints.paymentcategories).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_paymentCategories", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.Payor"))
                this.getAll<m.Payor>(ValueAPIEndpoints.payors).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_payors", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.VictimType"))
                this.getAll<m.VictimType>(ValueAPIEndpoints.victimtypes).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_victimTypes", JSON.stringify(o)) });
            if (this.checkForNewVersion(v, "AdvocacyPro.Models.Values.InterviewDocumentationType"))
                this.getAll<m.InterviewDocumentationType>(ValueAPIEndpoints.interviewdocumentationtypes).subscribe(o => { this.sortValueBase(o); localStorage.setItem("_interviewDocumentationTypes", JSON.stringify(o)) });
            
            this.uApi.getAll().subscribe(o => {
                    o.sort((a, b) => a.firstName + ' ' + a.lastName < b.firstName + ' ' + b.lastName ? -1 : 1);
                    sessionStorage.setItem("_users", JSON.stringify(o))
                });
        });
    }

    public get offenseTypes(): Array<m.OffenseType> {        
        return <Array<m.OffenseType>>JSON.parse(localStorage.getItem("_offenseTypes"));
    }
    public offenseType(id: number): m.OffenseType {
        return this.offenseTypes.filter(o => o.id == id)[0];
    }

    public get offenses(): Array<m.Offense> {
        return <Array<m.Offense>>JSON.parse(localStorage.getItem("_offenses"));
    }
    public offense(id: number): m.Offense {
        return this.offenses.filter(o => o.id == id)[0];
    }

    public get locationTypes(): Array<m.LocationType> {
        return <Array<m.LocationType>>JSON.parse(localStorage.getItem("_locationTypes"));
    }
    public locationType(id: number): m.LocationType {
        return this.locationTypes.filter(o => o.id == id)[0];
    }

    public get ageGroupings(): Array<m.AgeGrouping> {
        return <Array<m.AgeGrouping>>JSON.parse(localStorage.getItem("_ageGroupings"));
    }
    public ageGrouping(id: number): m.AgeGrouping {
        return this.ageGroupings.filter(o => o.id == id)[0];
    }

    public get caseContactTypes(): Array<m.ContactType> {
        return <Array<m.ContactType>>JSON.parse(localStorage.getItem("_caseContactTypes"));
    }
    public caseContactType(id: number): m.ContactType {
        return this.caseContactTypes.filter(o => o.id == id)[0];
    }

    public get caseDocumentTypes(): Array<m.DocumentType> {
        return <Array<m.DocumentType>>JSON.parse(localStorage.getItem("_caseDocumentTypes"));
    }
    public caseDocumentType(id: number): m.DocumentType {
        return this.caseDocumentTypes.filter(o => o.id == id)[0];
    }

    public get caseReferralTypes(): Array<m.ReferralType> {
        return <Array<m.ReferralType>>JSON.parse(localStorage.getItem("_caseReferralTypes"));
    }
    public caseReferralType(id: number): m.ReferralType {
        return this.caseReferralTypes.filter(o => o.id == id)[0];
    }

    public get caseServiceCategories(): Array<m.ServiceCategory> {
        return <Array<m.ServiceCategory>>JSON.parse(localStorage.getItem("_caseServiceCategories"));
    }
    public caseServiceCategory(id: number): m.ServiceCategory {
        return this.caseServiceCategories.filter(o => o.id == id)[0];
    }

    public get caseServicePopulations(): Array<m.ServicePopulation> {
        return <Array<m.ServicePopulation>>JSON.parse(localStorage.getItem("_caseServicePopulations"));
    }
    public caseServicePopulation(id: number): m.ServicePopulation {
        return this.caseServicePopulations.filter(o => o.id == id)[0];
    }

    public get caseServicePrograms(): Array<m.ServiceProgram> {
        return <Array<m.ServiceProgram>>JSON.parse(localStorage.getItem("_caseServicePrograms"));
    }
    public caseServiceProgram(id: number): m.ServiceProgram {
        return this.caseServicePrograms.filter(o => o.id == id)[0];
    }

    public get countries(): Array<m.Country> {
        return <Array<m.Country>>JSON.parse(localStorage.getItem("_countries"));
    }
    public country(id: number): m.Country {
        return this.countries.filter(o => o.id == id)[0];
    }

    public get ethnicities(): Array<m.Ethnicity> {
        return <Array<m.Ethnicity>>JSON.parse(localStorage.getItem("_ethnicities"));
    }
    public ethnicity(id: number): m.Ethnicity {
        return this.ethnicities.filter(o => o.id == id)[0];
    }

    public get fireCauses(): Array<m.FireCause> {
        return <Array<m.FireCause>>JSON.parse(localStorage.getItem("_fireCauses"));
    }
    public fireCause(id: number): m.FireCause {
        return this.fireCauses.filter(o => o.id == id)[0];
    }

    public get genders(): Array<m.Gender> {
        return <Array<m.Gender>>JSON.parse(localStorage.getItem("_genders"));
    }
    public gender(id: number): m.Gender {
        return this.genders.filter(o => o.id == id)[0];
    }

    public get orgTypes(): Array<m.OrganizationType> {
        return <Array<m.OrganizationType>>JSON.parse(localStorage.getItem("_orgTypes"));
    }
    public orgType(id: number): m.OrganizationType {
        return this.orgTypes.filter(o => o.id == id)[0];
    }

    public get races(): Array<m.Race> {
        return <Array<m.Race>>JSON.parse(localStorage.getItem("_races"));
    }
    public race(id: number): m.Race {
        return this.races.filter(o => o.id == id)[0];
    }

    public get relationshipTypes(): Array<m.RelationshipType> {
        return <Array<m.RelationshipType>>JSON.parse(localStorage.getItem("_relationshipTypes"));
    }
    public relationshipType(id: number): m.RelationshipType {
        return this.relationshipTypes.filter(o => o.id == id)[0];
    }

    public get states(): Array<m.State> {
        return <Array<m.State>>JSON.parse(localStorage.getItem("_states"));
    }
    public state(code: string): m.State {
        return this.states.filter(o => o.code == code)[0];
    }

    public get statuses(): Array<m.Status> {
        return <Array<m.Status>>JSON.parse(localStorage.getItem("_statuses"));
    }
    public status(id: number): m.Status {
        return this.statuses.filter(o => o.id == id)[0];
    }

    public get users(): Array<m.UserData> {
        return <Array<m.UserData>>JSON.parse(sessionStorage.getItem("_users"));
    }
    public user(id: number): m.UserData {
        return this.users.filter(o => o.id == id)[0];
    }

    public get applicationStatuses(): Array<m.ApplicationStatus> {
        return <Array<m.ApplicationStatus>>JSON.parse(localStorage.getItem("_applicationStatuses"));
    }
    public applicationStatus(id: number): m.ApplicationStatus {
        return this.applicationStatuses.filter(o => o.id == id)[0];
    }

    public get bondTypes(): Array<m.BondType> {
        return <Array<m.BondType>>JSON.parse(localStorage.getItem("_bondTypes"));
    }
    public bondType(id: number): m.BondType {
        return this.bondTypes.filter(o => o.id == id)[0];
    }

    public get docketTypes(): Array<m.DocketType> {
        return <Array<m.DocketType>>JSON.parse(localStorage.getItem("_docketTypes"));
    }
    public docketType(id: number): m.DocketType {
        return this.docketTypes.filter(o => o.id == id)[0];
    }
    
    public get interviewerPositions(): Array<m.InterviewerPosition> {
        return <Array<m.InterviewerPosition>>JSON.parse(localStorage.getItem("_interviewerPositions"));
    }
    public interviewerPosition(id: number): m.InterviewerPosition {
        return this.interviewerPositions.filter(o => o.id == id)[0];
    }

    public get languages(): Array<m.Language> {
        return <Array<m.Language>>JSON.parse(localStorage.getItem("_languages"));
    }
    public language(id: number): m.Language {
        return this.languages.filter(o => o.id == id)[0];
    }

    public get letterTypes(): Array<m.LetterType> {
        return <Array<m.LetterType>>JSON.parse(localStorage.getItem("_letterTypes"));
    }
    public letterType(id: number): m.LetterType {
        return this.letterTypes.filter(o => o.id == id)[0];
    }

    public get orderStatuses(): Array<m.OrderStatus> {
        return <Array<m.OrderStatus>>JSON.parse(localStorage.getItem("_orderStatuses"));
    }
    public orderStatus(id: number): m.OrderStatus {
        return this.orderStatuses.filter(o => o.id == id)[0];
    }

    public get orderTypes(): Array<m.OrderType> {
        return <Array<m.OrderType>>JSON.parse(localStorage.getItem("_orderTypes"));
    }
    public orderType(id: number): m.OrderType {
        return this.orderTypes.filter(o => o.id == id)[0];
    }
    
    public get paymentCategories(): Array<m.PaymentCategory> {
        return <Array<m.PaymentCategory>>JSON.parse(localStorage.getItem("_paymentCategories"));
    }
    public paymentCategory(id: number): m.PaymentCategory {
        return this.paymentCategories.filter(o => o.id == id)[0];
    }

    public get payors(): Array<m.Payor> {
        return <Array<m.Payor>>JSON.parse(localStorage.getItem("_payors"));
    }
    public payor(id: number): m.Payor {
        return this.payors.filter(o => o.id == id)[0];
    }

    public get victimTypes(): Array<m.VictimType> {
        return <Array<m.VictimType>>JSON.parse(localStorage.getItem("_victimTypes"));
    }
    public victimType(id: number): m.VictimType {
        return this.victimTypes.filter(o => o.id == id)[0];
    }

    public get interviewDocumentationTypes(): Array<m.InterviewDocumentationType> {
        return <Array<m.InterviewDocumentationType>>JSON.parse(localStorage.getItem("_interviewDocumentationTypes"));
    }
    public interviewDocumentationType(id: number): m.InterviewDocumentationType {
        return this.interviewDocumentationTypes.filter(o => o.id == id)[0];
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