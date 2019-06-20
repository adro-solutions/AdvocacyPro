import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { PopupResponse, PopupConfig } from '../models/popupConfig.model';
import { ToastMessageOptions } from '../models/toastOptions.model';

@Injectable({providedIn: 'root'})
export class CSPNotificationService {
    private response: Subject<PopupResponse>;
    private showSource: Subject<PopupConfig>;
    private showToast: Subject<any>;

    public modalTrigger: Observable<PopupConfig>;
    public toastTrigger: Observable<any>;

    constructor() {
        this.showSource = new Subject<PopupConfig>();
        this.showToast = new Subject<any>();
        this.modalTrigger = this.showSource.asObservable();
        this.toastTrigger = this.showToast.asObservable();
    }

    toast(options: ToastMessageOptions) {
        this.showToast.next(options);
    }

    showAlert(headerText: string, bodyText: string): Observable<PopupResponse> {
        this.response = new Subject<PopupResponse>();
        const config = new PopupConfig(headerText, bodyText);

        this.showSource.next(config);
        return this.response.asObservable();
    }

    showConfirm(headerText: string, bodyText: string): Observable<PopupResponse> {
        this.response = new Subject<PopupResponse>();
        const config = new PopupConfig(headerText, bodyText);
        config.cancelText = 'No';
        config.showCancel = true;
        config.okText = 'Yes';

        this.showSource.next(config);
        return this.response.asObservable();
    }

    showPrompt(headerText: string, bodyText: string, defaultValue: string): Observable<PopupResponse> {
        this.response = new Subject<PopupResponse>();
        const config = new PopupConfig(headerText, bodyText);
        config.cancelText = 'Cancel';
        config.showCancel = true;
        config.okText = 'Submit';
        config.inputValue = defaultValue;
        config.showInput = true;

        this.showSource.next(config);
        return this.response.asObservable();
    }

    popupClosed(response: PopupResponse) {
        this.response.next(response);
    }
}
