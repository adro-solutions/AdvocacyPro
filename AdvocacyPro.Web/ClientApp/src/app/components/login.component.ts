import { Component, Headers, Router, noop, Observable } from '../vendor';
import { HttpService, StateService, ValuesService, CSPNotificationService } from '../services';
import { UserData, Organization, Feature } from '../models';

@Component({
    template: require('./login.component.html'),
    providers: [HttpService],
    styleUrls: ['login.component.css']
})
export class LoginComponent {
    private userName: string;
    private password: string;

    constructor(private http: HttpService, private router: Router, private stateService: StateService,
        private valueService: ValuesService, private popupService: CSPNotificationService) { }

    public login() {
        let headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded'); // also tried other types to test if its working with other types, but no luck

        this.http.post('/api/Auth/token', 'username=' + this.userName +
                '&password=' + encodeURIComponent(this.password) + '&grant_type=password', { headers: headers })
            .subscribe(result => {
                Observable.forkJoin(
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
        this.popupService.showPrompt("Forgot your password?", "Confirm your email address below to reset your password", this.userName).subscribe(result => {
            if (result.response) {

                this.http.post('/api/Auth/ForgotPassword', { emailAddress: result.input }).subscribe(result => {
                    this.popupService.showAlert("Reset Password", "An email has been sent to the address provided with instructions on how to reset your password.");
                });  
            }              
        });
    }
}
