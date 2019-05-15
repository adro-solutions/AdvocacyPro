import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { CSPNotificationService } from '../services/notification.service';
import { FormService } from '../services/form.service';

@Component({
    template: './changepassword.component.html',
    styleUrls: ['changepassword.component.css']
})
export class ChangePasswordComponent implements OnInit {
    private changePwd: any;
    private submitted = false;
    formGroup: FormGroup;

    constructor(private http: HttpClient, private router: Router, private popupService: CSPNotificationService,
        private formService: FormService) { }

    ngOnInit() {
        this.changePwd = { currentPassword: '', newPassword: '', newPassword2: '' };
        this.formService.buildFormGroup<any>(this.changePwd, 'ChangePassword')
            .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
    }

    public changePassword(value: any) {
        this.submitted = true;
        if (this.formGroup.valid) {
            this.formService.buildObject(value, this.changePwd);
            if (this.changePwd.newPassword === this.changePwd.newPassword2) {
                this.http.post('/api/Auth/ChangePassword', this.changePwd).subscribe(result => {
                    this.popupService.showAlert('Change Password', 'Your password has been changed.').subscribe(result2 => {
                        this.router.navigate(['/dashboard']);
                    });
                });
            } else {
                this.popupService.showAlert('Password Mismatch', 'The new passwords you have entered do not match');
            }
        }
    }
}
