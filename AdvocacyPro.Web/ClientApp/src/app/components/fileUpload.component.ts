import { ElementRef, ViewChild, Input, Component } from '@angular/core';
import { CSPNotificationService } from '../services/notification.service';
import { ToastMessageOptions, ToastType } from '../models/toastOptions.model';

@Component({
    selector: 'app-file-upload',
    template: '<input type="file" (change)="fileChanged()" #fileInput>'
})
export class FileUploadComponent {
    public fileName = '';
    public formData: FormData;
    @ViewChild('fileInput', { static: true }) inputEl: ElementRef;
    @Input() maxSize: number;

    constructor(private notification: CSPNotificationService) { }

    public reset() {
        this.inputEl.nativeElement.value = '';
    }

    private fileChanged() {
        const inputEl: HTMLInputElement = this.inputEl.nativeElement;
        const fileCount: number = inputEl.files.length;
        if (fileCount > 0) { // a file was selected
            if (!!this.maxSize && inputEl.files.item(0).size > (this.maxSize * 1024 * 1024)) {
                this.inputEl.nativeElement.value = '';
                this.notification.toast(new ToastMessageOptions('File too large',
                    `Files must be under ${this.maxSize}MB and cannot be uploaded.`, ToastType.Error));
            } else {
                this.fileName = inputEl.files.item(0).name;
                this.formData = new FormData();
                this.formData.append('file[]', inputEl.files.item(0));
            }
        }
    }
}
