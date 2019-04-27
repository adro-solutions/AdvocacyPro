import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { StateService } from '../services/state.service';
import { AuthResponse } from '../models/auth-response.model';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    constructor(private router: Router, private state: StateService) { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this.state.authToken) {
            req = req.clone({ headers: req.headers.set('Authorization', `Bearer ${this.state.authToken}`) });
        }

        return next.handle(req).pipe(
            tap(res => {
                if (res instanceof HttpResponse && res.body) {
                    if ((<AuthResponse>res.body).token_type === 'Bearer') {
                        this.state.authToken = (<AuthResponse>res.body).access_token;
                    }
                }
            }),
            catchError(error => {
                if (error instanceof HttpErrorResponse) {
                    switch (error.status) {
                        case 401:
                            this.router.navigate(['login']);
                            return;
                    }
                }
                return of(error);
            })
        );
    }
}
