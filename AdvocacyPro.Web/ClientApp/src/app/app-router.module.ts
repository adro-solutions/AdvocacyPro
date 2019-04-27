import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { AppResolver } from './resolvers/app.resolver';
import { LoginComponent } from './components/login.component';
import { ChangePasswordComponent } from './components/changepassword.component';
import { ResetPasswordComponent } from './components/resetpassword.component';

const routes = [
  { path: '', resolve: {app: AppResolver}, children: [
    { path: 'resetpassword', component: ResetPasswordComponent },
    { path: 'changepassword', component: ChangePasswordComponent },
    { path: 'login', component: LoginComponent }
  ] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
