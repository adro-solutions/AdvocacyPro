import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { StateService } from '../services/state.service';
import { ValuesService } from '../services/values.service';
import { CSPNotificationService } from '../services/notification.service';
import { Observable, noop, forkJoin } from 'rxjs';
import { UserData } from '../models/userData.model';
import { Feature } from '../models/feature.model';
import { Organization } from '../models/valueBase.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
    templateUrl: './login.component.html',
    styleUrls: ['login.component.css']
})
export class LoginComponent {
    private userName: string;
    private password: string;

    constructor(private http: HttpClient, private router: Router, private stateService: StateService,
        private valueService: ValuesService, private popupService: CSPNotificationService) { }

    public login() {
        const headers = new HttpHeaders();
        // also tried other types to test if its working with other types, but no luck
        headers.append('Content-Type', 'application/x-www-form-urlencoded');

        this.http.post('/api/Auth/token', 'username=' + this.userName +
                '&password=' + encodeURIComponent(this.password) + '&grant_type=password', { headers: headers })
            .subscribe(result => {
                forkJoin(
                    this.http.get<UserData>('/api/Users/Current'),
                    this.http.get<Feature[]>('api/Users/Current/Features'),
                    this.http.get<Organization>('/api/Organizations/Current')
                ).subscribe(d => {
                    this.valueService.initialize();

                    this.stateService.user = d[0];
                    this.stateService.features = d[1];
                    this.stateService.organization = d[2];

                    this.router.navigate(['/dashboard']);
                });
            },
            error => noop());
    }

    public forgotPassword() {
        this.popupService.showPrompt('Forgot your password?',
            'Confirm your email address below to reset your password', this.userName).subscribe(result => {
            if (result.response) {
                this.http.post('/api/Auth/ForgotPassword', { emailAddress: result.input }).subscribe(() => {
                    this.popupService.showAlert('Reset Password',
                        'An email has been sent to the address provided with instructions on how to reset your password.');
                });
            }
        });
    }
}
