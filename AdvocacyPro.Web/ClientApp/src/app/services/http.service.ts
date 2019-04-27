import {
    Injectable, Http, Headers, Response, Request, RequestOptions, RequestOptionsArgs,
    Router, Observable, ResponseContentType
} from '../vendor';
import { StateService, ConvertService, CSPNotificationService } from './';
import { ToastMessageOptions, ToastType } from '../models';
import * as moment from 'moment';

@Injectable()
export class HttpService {
    constructor(private http: Http, private state: StateService, private router: Router, private convert: ConvertService,
        private nService: CSPNotificationService) { }
    
    get<T>(url: string, options?: RequestOptionsArgs): Observable<T> {

        this.requestInterceptor();
        return this.http.get(this.getFullUrl(url), this.requestOptions(options))
            .catch(this.onCatch)
            .do((res: Response) => {
                this.onSubscribeSuccess(res);
            }, (error: any) => {
                this.onSubscribeError(error);
            })
            .finally(() => {
                this.onFinally();
            })
            .map(response => { return this.datesToLocal(response) as T; });
    }

    download(url: string, options?: RequestOptionsArgs): Observable<Blob> {
        this.requestInterceptor();
        return this.http.get(url, this.requestOptions({ responseType: ResponseContentType.Blob }))
            .map((res: Response) => res["_body"]);
    }

    post<T>(url: string, body: T, options?: RequestOptionsArgs): Observable<T> {
        this.requestInterceptor();
        return this.http.post(this.getFullUrl(url), this.datesToUTC(body), this.requestOptions(options))
            .catch(this.onCatch)
            .do((res: Response) => {
                this.onSubscribeSuccess(res);
            }, (error: any) => {
                this.onSubscribeError(error);
            })
            .finally(() => {
                this.onFinally();
            })
            .map(response => { return this.datesToLocal(response) as T; });
    }

    postWithReturnType<T,U>(url: string, body: T, options?: RequestOptionsArgs): Observable<U> {
        this.requestInterceptor();
        return this.http.post(this.getFullUrl(url), this.datesToUTC(body), this.requestOptions(options))
            .catch(this.onCatch)
            .do((res: Response) => {
                this.onSubscribeSuccess(res);
            }, (error: any) => {
                this.onSubscribeError(error);
            })
            .finally(() => {
                this.onFinally();
            })
            .map(response => { return this.datesToLocal(response) as U; });
    }

    put<T>(url: string, body: T, options?: RequestOptionsArgs): Observable<T> {
        this.requestInterceptor();
        return this.http.put(this.getFullUrl(url), this.datesToUTC(body), this.requestOptions(options))
            .catch(this.onCatch)
            .do((res: Response) => {
                this.onSubscribeSuccess(res);
            }, (error: any) => {
                this.onSubscribeError(error);
            })
            .finally(() => {
                this.onFinally();
            })
            .map(response => { return this.datesToLocal(response) as T; });
    }

    delete<T>(url: string, options?: RequestOptionsArgs): Observable<T> {
        this.requestInterceptor();
        return this.http.delete(this.getFullUrl(url), this.requestOptions(options))
            .catch(this.onCatch)
            .do((res: Response) => {
                this.onSubscribeSuccess(res);
            }, (error: any) => {
                this.onSubscribeError(error);
            })
            .finally(() => {
                this.onFinally();
            });
    }

    private datesToLocal(res: Response): any {
        let obj: any;

        if (res["_body"] != undefined && res["_body"] != "") {
            let json = res.json();

            obj = this.localizeDateObject(json);
        }
        
        return obj;
    }

    

    private localizeDateObject(json: any): any {
        let obj: any = {};
        
        if (Array.isArray(json)) {
            obj = [];
            json.forEach(o => obj.push(this.localizeDateObject(o)));
        } else if (typeof json == "string" || typeof json == "number") {
            return json;
        } else {
            for (let key of Object.keys(json)) {
                let jVal = json[key];

                if (!!jVal && typeof (jVal) == "object") {
                    obj[key] = this.localizeDateObject(jVal);
                } else {
                    // from the API, any date will be UTC, so convert it to local.
                    if (this.convert.isValidDate(jVal, true))
                        obj[key] = this.convert.UTCtoLocalTime(jVal);
                    else
                        obj[key] = jVal;
                }                
            }
        }        
        
        return obj;
    }

    private datesToUTC(json: any): any {
        let obj: any = {};

        if (typeof (json) === 'string' || typeof (json) === 'number' || json instanceof FormData)
            return json

        if (Array.isArray(json)) {
            obj = [];
            json.forEach(o => obj.push(this.localizeDateObject(o)));
        } else {
            for (let key of Object.keys(json)) {
                let jVal = json[key];

                if (!!jVal && typeof (jVal) == "object" && !this.convert.isValidDate(jVal)) {
                    obj[key] = this.localizeDateObject(jVal);
                } else {                    

                    if (this.convert.isValidDate(jVal, true)) {
                        obj[key] = this.convert.localTimeToUTC(jVal);
                    }
                    else
                        obj[key] = jVal;
                }
            }
        }

        return obj;
    }

    private requestOptions(options?: RequestOptionsArgs): RequestOptionsArgs {
        if (options == null) {
            options = new RequestOptions();
        }
        if (options.headers == null) {
            options.headers = new Headers();
        }

        if (this.state.authToken)
            options.headers.append('Authorization', 'Bearer ' + this.state.authToken);

        return options;
    }

    private getFullUrl(url: string): string {
        return url;
    }

    private requestInterceptor(): void {
    }

    private responseInterceptor(): void {

    }

    private onCatch(error: any, caught: Observable<any>): Observable<any> {
        return Observable.throw(error);
    }

    private onSubscribeSuccess(res: Response): void {
        if (res["_body"] != undefined && res["_body"] != "") {
            let resBody = res.json();

            if (resBody.token_type == 'Bearer') {
                this.state.authToken = resBody.access_token;
            }
        }
    }

    private onSubscribeError(error: any): void {
        switch (error.status) {
            case 401: this.router.navigate(['login']); break;
            case 400:
                if (error["_body"] != undefined && error["_body"] != "") {
                    let erBody = error.json();
                    let message = "<ul>";

                    for (let key of Object.keys(erBody)) {
                        message += "<li>" + key + "<ul>";
                        if (erBody[key].length > 0)
                            erBody[key].forEach(i => message += "<li>" + i + "</li>");
                        message += "</ul></li>"
                    }

                    message += "</ul>";
                    let options = new ToastMessageOptions("The following error occurred", message, ToastType.Error);

                    this.nService.toast(options);
                }
                
                break;
        }
        if (error.headers.get("x-exceptionmessage")) {
            let options = new ToastMessageOptions("Error", error.headers.get("x-exceptionmessage"), ToastType.Error);

            this.nService.toast(options);
        }

    }

    private onFinally(): void {
        this.responseInterceptor();
    }
}