import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

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
    HeaderComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
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
