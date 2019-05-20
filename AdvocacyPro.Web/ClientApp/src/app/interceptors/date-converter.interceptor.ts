import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { map, tap, catchError } from 'rxjs/operators';
import { ConvertService } from '../services/convert.service';

@Injectable()
export class DateConverterInterceptor implements HttpInterceptor {
    constructor(private convert: ConvertService) { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        req = req.clone({ body: this.datesToUTC(req.body) });

        return next.handle(req).pipe(
            map(res => {
                if (res instanceof HttpResponse && res.body) {
                    return res.clone({ body: this.localizeDateObject(res.body) });
                }
            },
            catchError(error => {
                return throwError(error);
            })));
    }

    private localizeDateObject(json: any): any {
        let obj: any = {};

        if (Array.isArray(json)) {
            obj = [];
            json.forEach(o => obj.push(this.localizeDateObject(o)));
        } else if (typeof json === 'string' || typeof json === 'number') {
            return json;
        } else {
            Object.keys(json).forEach(key => {
                const jVal = json[key];

                if (!!jVal && typeof (jVal) === 'object') {
                    obj[key] = this.localizeDateObject(jVal);
                } else {
                    // from the API, any date will be UTC, so convert it to local.
                    if (this.convert.isValidDate(jVal, true)) {
                        obj[key] = this.convert.UTCtoLocalTime(jVal);
                    } else {
                        obj[key] = jVal;
                    }
                }
            });
        }

        return obj;
    }

    private datesToUTC(json: any): any {
        let obj: any = {};

        if (typeof (json) === 'string' || typeof (json) === 'number' || json instanceof FormData ||
        json === null || json === undefined) {
            return json;
        }

        if (Array.isArray(json)) {
            obj = [];
            json.forEach(o => obj.push(this.localizeDateObject(o)));
        } else {
            Object.keys(json).forEach(key => {
                const jVal = json[key];

                if (!!jVal && typeof (jVal) === 'object' && !this.convert.isValidDate(jVal)) {
                    obj[key] = this.localizeDateObject(jVal);
                } else {
                    if (this.convert.isValidDate(jVal, true)) {
                        obj[key] = this.convert.localTimeToUTC(jVal);
                    } else {
                        obj[key] = jVal;
                    }
                }
            });
        }

        return obj;
    }

}
