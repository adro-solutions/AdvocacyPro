import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormControl } from '../models/formControl.model';

@Component({
    selector: 'app-form-errors',
    templateUrl: './formerrors.component.html'
})
export class FormErrorsComponent implements OnInit {
    @Input() formGroup: FormGroup;
    errorMessages: Array<any>;

    ngOnInit() {
        this.buildErrorMessages();

        this.formGroup.valueChanges.subscribe(data => {
            this.buildErrorMessages();
        });
    }

    buildErrorMessages() {
        this.errorMessages = [];

        for (const key of Object.keys(this.formGroup.controls)) {
            const fc: FormControl = <FormControl>this.formGroup.controls[key];

            const errors = fc.errors;
            if (errors != null) {
                let displayKey = key.charAt(0).toUpperCase() + key.slice(1);

                if (fc.displayName != null && fc.displayName !== undefined && fc.displayName !== '') {
                    displayKey = fc.displayName;
                }

                if (errors['required']) {
                    this.errorMessages.push(displayKey + ' is a required field.');
                }
                if (errors['maxlength']) {
                    this.errorMessages.push(displayKey + ' cannot be longer than ' + errors['maxlength'].requiredLength + '.');
                }
                if (errors['minlength']) {
                    this.errorMessages.push(displayKey + ' must be longer than ' + errors['minlength'].requiredLength + '.');
                }
                if (errors['range']) {
                    this.errorMessages.push(`${displayKey} must be between ${errors['range'].minValue} and ${errors['range'].maxValue}`);
                }
                if (errors['email']) {
                    this.errorMessages.push(displayKey + ' must be a valid email address.');
                }
                if (errors['phone']) {
                    this.errorMessages.push(displayKey + ' must be a valid phone number.');
                }
                if (errors['pattern']) {
                    if (key.toLowerCase() === 'password' || key.toLowerCase() === 'currentpassword' ||
                        key.toLowerCase() === 'newpassword' || key.toLowerCase() === 'newpassword2') {
                        this.errorMessages.push('Password must contain: 1 upper case letter, ' +
                            '1 lower case letter, 1 number, and 1 special (*[!#$%&?]) character.');
                    }
                }
            }
        }
    }
}
