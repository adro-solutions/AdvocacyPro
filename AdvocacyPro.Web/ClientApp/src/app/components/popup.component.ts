import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalComponent } from './modal.component';
import { PopupConfig, PopupResponse } from '../models/popupConfig.model';
import { CSPNotificationService } from '../services/notification.service';

@Component({
    selector: 'app-popup-modal',
    templateUrl: './popup.component.html'
})
export class PopupComponent implements OnInit {
    @ViewChild(ModalComponent) public readonly modal: ModalComponent;
    config: PopupConfig;

    constructor(private popupService: CSPNotificationService) {
        this.config = new PopupConfig(null, null);
    }

    ngOnInit() {
        this.popupService.modalTrigger.subscribe(config => {
            this.config = config;
            this.modal.show();
        });
    }

    ok(): void {
        this.modal.hide();
        this.popupService.popupClosed(new PopupResponse(true, this.config.inputValue));
    }

    cancel(): void {
        this.modal.hide();
        this.popupService.popupClosed(new PopupResponse(false, this.config.inputValue));
    }
}
