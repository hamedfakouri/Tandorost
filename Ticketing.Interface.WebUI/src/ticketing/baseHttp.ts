import {Injectable} from "@angular/core";
import { ConnectionBackend, RequestOptions, Request, RequestOptionsArgs, Response, Http, Headers} from "@angular/http";
import {Observable} from "rxjs/Rx";
import { environment } from "../environments/environment";
import { StartupService } from './startupService';
import { CookieService } from 'ngx-cookie-service';
import { BaseTicketingService } from './../ticketing/baseTicketingService';
export { BaseTicketingService };

@Injectable()
export class BaseHttp {
    private _token: any;

    tokenValue = 'UNKNOWN';
    tokenType = 'UNKNOWN';

    constructor(defaultOptions: RequestOptions
        , public cookieService: CookieService, public http: Http, public baseService: BaseTicketingService) {
    }

    get(url: string, options?: RequestOptionsArgs): Observable<Response> {
        url = this.updateUrl(url);
        var res = this.http.get(url, this.getRequestOptionArgs(options));
        return res;
    }

    post(url: string, body: any, options?: RequestOptionsArgs): Observable<Response> {
        debugger;
        url = this.updateUrl(url);
        let bodyData = JSON.stringify(body);
        return this.http.post(url, bodyData, this.getRequestOptionArgs(options));
    }

    put(url: string, body: string, options?: RequestOptionsArgs): Observable<Response> {
        url = this.updateUrl(url);
        let bodyData = JSON.stringify(body);
        return this.http.put(url, bodyData, this.getRequestOptionArgs(options));
    }

    delete(url: string, options?: RequestOptionsArgs): Observable<Response> {
        url = this.updateUrl(url);
        return this.http.delete(url, this.getRequestOptionArgs(options));
    }
    
    private updateUrl(req: string) {
        debugger;
        var res = this.baseService.getserviceUrl() + req;
        return res;
    }

    private getRequestOptionArgs(options?: RequestOptionsArgs): RequestOptionsArgs {
        debugger;
        if (options == null) {
            options = new RequestOptions();
        }
        if (options.headers == null) {
            options.headers = new Headers();
        }
        options.headers.append('Authorization', this.getToken());


        return options;
    }
    getToken(): string {
        this._token = null;
        this.tokenValue = this.cookieService.get('token');
        this.tokenType = this.cookieService.get('tokenType');
        this._token = this.tokenType + " " + this.tokenValue;
        return this._token;
    }
}