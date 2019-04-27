﻿import { Input, Component } from '@angular/core';

@Component({
    selector: 'app-modal',
    template: require('./modal.component.html'),
    styleUrls: ['modal.component.css']
})
export class ModalComponent {
    public visible = false;
    private visibleAnimate = false;
    @Input() showCloseButton = true;
    @Input() large = false;

    public show(): void {
        this.visible = true;
        setTimeout(() => this.visibleAnimate = true);
    }

    public hide(): void {
        this.visibleAnimate = false;
        setTimeout(() => this.visible = false, 300);
    }
}
