import { Component, Router, ActivatedRoute, OnInit, FormGroup } from '../vendor';
import { HttpService, CSPNotificationService, FormService } from '../services';

@Component({
    template: require('./resetpassword.component.html'),
    providers: [HttpService],
    styleUrls: ['resetpassword.component.css']
})
export class ResetPasswordComponent implements OnInit {
    private resetPwd: any;
    private submitted = false;
    formGroup: FormGroup;

    constructor(private http: HttpService, private router: Router, private popupService: CSPNotificationService,
        private route: ActivatedRoute, private formService: FormService) { }

    ngOnInit() {
        this.resetPwd = { email: "", code: "", newPassword: "", newPassword2: "" };
        this.formService.buildFormGroup<any>(this.resetPwd, "ResetPassword")
            .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
        this.route.queryParams.subscribe(params => {
            this.resetPwd.code = params["code"];
        });
    }

    public changePassword(value: any) {
        this.submitted = true;
        if (this.formGroup.valid) {
            this.formService.buildObject(value, this.resetPwd);
            if (this.resetPwd.newPassword === this.resetPwd.newPassword2) {
                this.http.post('/api/Auth/ResetPassword', this.resetPwd).subscribe(result => {
                    this.popupService.showAlert("Reset Password", "Your password has been changed. Please log in.").subscribe(result2 => {
                        this.router.navigate(['/login']);
                    });
                });
            } else {
                this.popupService.showAlert("Password Mismatch", "The new passwords you have entered do not match");
            }
        }
    }
}
