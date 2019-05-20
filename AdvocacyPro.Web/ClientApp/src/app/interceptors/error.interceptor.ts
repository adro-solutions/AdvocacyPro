import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { CSPNotificationService } from '../services/notification.service';
import { ToastMessageOptions, ToastType } from '../models/toastOptions.model';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private nService: CSPNotificationService) { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError(error => {
                if (error instanceof HttpErrorResponse) {
                    switch (error.status) {
                        case 401:
                            return throwError(error);
                        default:
                            let message = '<ul>';
                            Object.keys(error).forEach(key => {
                                message += `<li>${key}<ul>`;
                                if (error[key].length > 0) {
                                    error[key].forEach(i => message += `<li>${i}</li>`);
                                }
                                message += '</ul></li>';
                            });

                            message += '</ul>';
                            const options = new ToastMessageOptions('The following error occurred', message, ToastType.Error);
                            this.nService.toast(options);
                            break;
                    }
                }
                if (error.headers.get('x-exceptionmessage')) {
                    const options = new ToastMessageOptions('Error', error.headers.get('x-exceptionmessage'), ToastType.Error);
                    this.nService.toast(options);
                }

                return of(error);
            })
        );
    }
}
