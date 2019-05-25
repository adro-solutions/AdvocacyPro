import { CSPNotificationService } from './../services/notification.service';
import { ViewEncapsulation, ViewContainerRef, Component, OnInit } from '@angular/core';
import { ToastMessageOptions, ToastType } from '../models/toastOptions.model';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app',
    styleUrls: ['app.component.css'],
    encapsulation: ViewEncapsulation.None,
    templateUrl: './app.component.html'
})
export class AppComponent implements OnInit  {
    constructor(private nService: CSPNotificationService, public toastr: ToastrService, vcr: ViewContainerRef) {
        // this.toastr.setRootViewContainerRef(vcr);
    }

    ngOnInit() {
        this.nService.toastTrigger.subscribe((config: ToastMessageOptions) => {
            switch (config.type) {
                case ToastType.Error: this.toastr.error(config.body, config.title, { enableHtml: true }); break;
                case ToastType.Info: this.toastr.info(config.body, config.title, { enableHtml: true }); break;
                case ToastType.Warning: this.toastr.warning(config.body, config.title, { enableHtml: true }); break;
                case ToastType.Success: this.toastr.success(config.body, config.title, { enableHtml: true }); break;
            }
        });
    }
}
