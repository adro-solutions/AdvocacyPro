import { Component } from '@angular/core';

@Component({
    selector: 'app-site-footer',
    templateUrl: './footer.component.html'
})
export class FooterComponent {
    private version: string;
    private copyright: number;

    constructor() {
        this.version = '1.0.0';
        this.copyright = new Date().getFullYear();
    }
}
