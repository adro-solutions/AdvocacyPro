import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CSPNotificationService } from '../services/notification.service';
import { FormService } from '../services/form.service';
import { HttpClient } from '@angular/common/http';

@Component({
    template: './resetpassword.component.html',
    styleUrls: ['resetpassword.component.css']
})
export class ResetPasswordComponent implements OnInit {
    private resetPwd: any;
    public submitted = false;
    formGroup: FormGroup;

    constructor(private http: HttpClient, private router: Router, private popupService: CSPNotificationService,
        private route: ActivatedRoute, private formService: FormService) { }

    ngOnInit() {
        this.resetPwd = { email: '', code: '', newPassword: '', newPassword2: '' };
        this.formService.buildFormGroup<any>(this.resetPwd, 'ResetPassword')
            .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
        this.route.queryParams.subscribe(params => {
            this.resetPwd.code = params['code'];
        });
    }

    public changePassword(value: any) {
        this.submitted = true;
        if (this.formGroup.valid) {
            this.formService.buildObject(value, this.resetPwd);
            if (this.resetPwd.newPassword === this.resetPwd.newPassword2) {
                this.http.post('/api/Auth/ResetPassword', this.resetPwd).subscribe(() => {
                    this.popupService.showAlert('Reset Password', 'Your password has been changed. Please log in.').subscribe(() => {
                        this.router.navigate(['/login']);
                    });
                });
            } else {
                this.popupService.showAlert('Password Mismatch', 'The new passwords you have entered do not match');
            }
        }
    }
}
