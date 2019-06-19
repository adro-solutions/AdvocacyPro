import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { AppResolver } from './resolvers/app.resolver';
import { LoginComponent } from './components/login.component';
import { ChangePasswordComponent } from './components/changepassword.component';
import { ResetPasswordComponent } from './components/resetpassword.component';
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
import { HomeComponent } from './components/home.component';

const routes = [
  { path: 'resetpassword', component: ResetPasswordComponent },
  { path: 'changepassword', component: ChangePasswordComponent },
  { path: 'login', component: LoginComponent },
  {
    path: '', resolve: { app: AppResolver }, component: HomeComponent, children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'cases/:caseId/contacts/:id', component: ContactComponent },
      { path: 'cases/:caseId/courtdates/:id', component: CourtDateComponent },
      { path: 'cases/:caseId/cvcapplications/:id', component: CVCApplicationComponent },
      { path: 'cases/:caseId/documents/:id', component: DocumentComponent },
      { path: 'cases/:caseId/emergencycontacts/:id', component: EmergencyContactComponent },
      { path: 'cases/:caseId/incidents/:id', component: IncidentComponent },
      { path: 'cases/:caseId/interviews/:id', component: InterviewComponent },
      { path: 'cases/:caseId/letters/:id', component: LetterComponent },
      { path: 'cases/:caseId/notes/:id', component: NoteComponent },
      { path: 'cases/:caseId/offenders/:id', component: OffenderComponent },
      { path: 'cases/:caseId/payments/:id', component: PaymentComponent },
      { path: 'cases/:caseId/police/:id', component: PoliceCaseComponent },
      { path: 'cases/:caseId/protectiveorders/:id', component: ProtectiveOrderComponent },
      { path: 'cases/:caseId/referrals/:id', component: ReferralComponent },
      { path: 'cases/:caseId/services/:id', component: ServiceProvidedComponent },
      { path: 'cases/:caseId/victimizations/:id', component: VictimizationComponent },
      { path: 'cases/:caseId/witnesses/:id', component: WitnessComponent },
      { path: 'cases', component: CasesComponent },
      { path: 'cases/:caseId/:tab', component: CaseComponent },
      { path: 'cases/:caseId', component: CaseComponent },
      { path: 'fires', component: FiresComponent },
      { path: 'fires/:id', component: FireComponent },
      {
          path: 'reports', children: [
              { path: 'crime-log', component: CrimeLogComponent },
              { path: 'fire-log', component: FireLogComponent },
              { path: 'crime-statistics', component: CrimeStatisticsComponent },
              { path: 'performance-demographics', component: PerformanceDemographicsComponent },
              { path: 'performance-services', component: PerformanceServicesComponent },
              { path: 'performance-victimizations', component: PerformanceVictimizationsComponent },
          ]
      },
      { path: 'documentation', component: DocumentationComponent },
      {
          path: 'admin', children: [
              { path: 'members', component: MembersComponent },
              { path: 'organizations', component: OrganizationsComponent },
              { path: 'organizations/:id', component: OrganizationComponent },
              {
                  path: 'values', children: [
                      { path: 'serviceprograms', component: ServiceProgramsComponent },
                      { path: 'serviceprograms/:id', component: ServiceProgramComponent },
                      { path: 'offenses', component: OffensesComponent },
                      { path: 'offenses/:id', component: OffenseComponent },
                      { path: 'races', component: RacesComponent },
                      { path: 'races/:id', component: RaceComponent },
                      { path: 'states', component: StatesComponent },
                      { path: 'states/:id', component: StateComponent },
                      { path: ':type', component: ValueListComponent },
                      { path: ':type/:id', component: ValueComponent }
                  ]
              }
          ]
      }
  ]
},
{ path: '**', redirectTo: 'dashboard' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
