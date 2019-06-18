import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CalendarModule } from 'primeng/calendar';
import { InputMaskModule } from 'primeng/inputmask';
import { AutoCompleteModule } from 'primeng/autocomplete';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-router.module';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { DateConverterInterceptor } from './interceptors/date-converter.interceptor';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { ResetPasswordComponent } from './components/resetpassword.component';
import { ChangePasswordComponent } from './components/changepassword.component';
import { HomeComponent } from './components/home.component';
import { LoginComponent } from './components/login.component';
import { FormErrorsComponent } from './components/formerrors.component';
import { FooterComponent } from './components/footer.component';
import { NavMenuComponent } from './components/navmenu.component';
import { HeaderComponent } from './components/header.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ContactComponent } from './components/cases/contact.component';
import { CourtDateComponent } from './components/cases/courtdate.component';
import { CVCApplicationComponent } from './components/cases/cvcapplication.component';
import { DocumentComponent } from './components/cases/document.component';
import { EmergencyContactComponent } from './components/cases/emergencycontact.component';
import { IncidentComponent } from './components/cases/incident.component';
import { InterviewComponent } from './components/cases/interview.component';
import { LetterComponent } from './components/cases/letter.component';
import { NoteComponent } from './components/cases/note.component';
import { OffenderComponent } from './components/cases/offender.component';
import { PaymentComponent } from './components/cases/payment.component';
import { PoliceCaseComponent } from './components/cases/policecase.component';
import { ProtectiveOrderComponent } from './components/cases/protectiveorder.component';
import { ReferralComponent } from './components/cases/referral.component';
import { ServiceProvidedComponent } from './components/cases/serviceProvided.component';
import { VictimizationComponent } from './components/cases/victimization.component';
import { WitnessComponent } from './components/cases/witness.component';
import { CasesComponent } from './components/cases/cases.component';
import { CaseComponent } from './components/cases/case.component';
import { FiresComponent } from './components/fires/fires.component';
import { FireComponent } from './components/fires/fire.component';
import { CrimeLogComponent } from './components/reports/crimeLog.component';
import { FireLogComponent } from './components/reports/fireLog.component';
import { CrimeStatisticsComponent } from './components/reports/crimeStatistics.component';
import { PerformanceDemographicsComponent } from './components/reports/performanceDemographics.component';
import { PerformanceServicesComponent } from './components/reports/performanceServices.component';
import { PerformanceVictimizationsComponent } from './components/reports/performanceVictimizations.component';
import { DocumentationComponent } from './components/documentation/documentation.component';
import { MembersComponent } from './components/admin/members.component';
import { OrganizationsComponent } from './components/admin/organizations.component';
import { OrganizationComponent } from './components/admin/organization.component';
import { ServiceProgramsComponent } from './components/admin/values/servicePrograms.component';
import { ServiceProgramComponent } from './components/admin/values/serviceProgram.component';
import { OffensesComponent } from './components/admin/values/offenses.component';
import { OffenseComponent } from './components/admin/values/offense.component';
import { RacesComponent } from './components/admin/values/races.component';
import { RaceComponent } from './components/admin/values/race.component';
import { StatesComponent } from './components/admin/values/states.component';
import { StateComponent } from './components/admin/values/state.component';
import { ValueListComponent } from './components/admin/values/valueList.component';
import { ValueComponent } from './components/admin/values/value.component';
import { FileUploadComponent } from './components/fileUpload.component';
import { LastEditInfoComponent } from './components/cases/lasteditinfo.component';
import { IncidentsComponent } from './components/cases/incidents.component';
import { EmergencyContactsComponent } from './components/cases/emergencycontacts.component';
import { ReferralsComponent } from './components/cases/referrals.component';
import { ServicesProvidedComponent } from './components/cases/servicesProvided.component';
import { NotesComponent } from './components/cases/notes.component';
import { ContactLogComponent } from './components/cases/contactlog.component';
import { DocumentsComponent } from './components/cases/documents.component';
import { WitnessesComponent } from './components/cases/witnesses.component';
import { PoliceCaseLogComponent } from './components/cases/policecaselog.component';
import { OffendersComponent } from './components/cases/offenders.component';
import { CourtDatesComponent } from './components/cases/courtdates.component';
import { CVCApplicationsComponent } from './components/cases/cvcapplications.component';
import { InterviewsComponent } from './components/cases/interviews.component';
import { LettersComponent } from './components/cases/letters.component';
import { PaymentsComponent } from './components/cases/payments.component';
import { ProtectiveOrdersComponent } from './components/cases/protectiveorders.component';
import { VictimizationsComponent } from './components/cases/victimizations.component';
import { MemberComponent } from './components/admin/member.component';
import { MemberFeatureComponent } from './components/admin/memberFeature.component';
import { ModalComponent } from './components/modal.component';

@NgModule({
  declarations: [
    AppComponent,
    ResetPasswordComponent,
    ChangePasswordComponent,
    HomeComponent,
    LoginComponent,
    FormErrorsComponent,
    FooterComponent,
    NavMenuComponent,
    HeaderComponent,
    DashboardComponent,

    ContactComponent,
    CourtDateComponent,
    CVCApplicationComponent,
    DocumentComponent,
    EmergencyContactComponent,
    IncidentComponent,
    InterviewComponent,
    LetterComponent,
    NoteComponent,
    OffenderComponent,
    PaymentComponent,
    PoliceCaseComponent,
    ProtectiveOrderComponent,
    ReferralComponent,
    ServiceProvidedComponent,
    VictimizationComponent,
    WitnessComponent,
    CasesComponent,
    CaseComponent,
    FiresComponent,
    FireComponent,
    CrimeLogComponent,
    FireLogComponent,
    CrimeStatisticsComponent,
    PerformanceDemographicsComponent,
    PerformanceServicesComponent,
    PerformanceVictimizationsComponent,
    DocumentationComponent,
    MembersComponent,
    OrganizationsComponent,
    OrganizationComponent,
    ServiceProgramsComponent,
    ServiceProgramComponent,
    OffensesComponent,
    OffenseComponent,
    RacesComponent,
    RaceComponent,
    StatesComponent,
    StateComponent,
    ValueListComponent,
    ValueComponent,
    FileUploadComponent,
    LastEditInfoComponent,
    IncidentsComponent,
    EmergencyContactsComponent,
    ReferralsComponent,
    ServicesProvidedComponent,
    NotesComponent,
    ContactLogComponent,
    DocumentsComponent,
    WitnessesComponent,
    PoliceCaseLogComponent,
    OffendersComponent,
    CourtDatesComponent,
    CVCApplicationsComponent,
    InterviewsComponent,
    LettersComponent,
    PaymentsComponent,
    ProtectiveOrdersComponent,
    VictimizationsComponent,
    MembersComponent,
    MemberComponent,
    MemberFeatureComponent,
    ModalComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    CalendarModule,
    InputMaskModule,
    AutoCompleteModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true,
  },
  {
    provide: HTTP_INTERCEPTORS,
    useClass: DateConverterInterceptor,
    multi: true,
  },
  {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
    multi: true,
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
