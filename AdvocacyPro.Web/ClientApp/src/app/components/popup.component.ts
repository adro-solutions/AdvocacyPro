import { Component, ViewChild, Input, FormGroup, Observable, Subject, OnInit } from '../vendor';
import { ModalComponent } from './';
import { CSPNotificationService } from '../services';
import { PopupConfig, PopupResponse } from '../models';

@Component({
    selector: 'popup-modal',
    template: require('./popup.component.html')
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
