import {Injectable} from "@angular/core";
import { ConnectionBackend, RequestOptions, Request, RequestOptionsArgs, Response, Http, Headers} from "@angular/http";
import {Observable} from "rxjs/Rx";
import { environment } from "../environments/environment";
import { StartupService } from './startupService'
import { CookieService } from 'ngx-cookie-service'
import { BaseTicketingService } from './../ticketing/baseTicketingService'
@Injectable()
export class InterceptedHttp extends Http {
    private _token: any;

    tokenValue = 'UNKNOWN';
    tokenType = 'UNKNOWN';

    constructor(backend: ConnectionBackend, defaultOptions: RequestOptions
        , private cookieService: CookieService, private baseService: BaseTicketingService) {
        super(backend, defaultOptions);
    }

    get(url: string, options?: RequestOptionsArgs): Observable<Response> {
        url = this.updateUrl(url);

        var res = super.get(url, this.getRequestOptionArgs(options));
        return res;
    }

    post(url: string, body: string, options?: RequestOptionsArgs): Observable<Response> {
        url = this.updateUrl(url);
        return super.post(url, body, this.getRequestOptionArgs(options));
    }

    put(url: string, body: string, options?: RequestOptionsArgs): Observable<Response> {
        url = this.updateUrl(url);
        return super.put(url, body, this.getRequestOptionArgs(options));
    }

    delete(url: string, options?: RequestOptionsArgs): Observable<Response> {
        url = this.updateUrl(url);
        return super.delete(url, this.getRequestOptionArgs(options));
    }
    
    private updateUrl(req: string) {

        var res = this.baseService.getserviceUrl() + req;
        return res;
    }

    private getRequestOptionArgs(options?: RequestOptionsArgs) : RequestOptionsArgs {
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
        debugger;
        this.tokenValue = this.cookieService.get('token');
        this.tokenType = this.cookieService.get('tokenType');
        this._token = this.tokenType + " " + this.tokenValue;

        return this._token;
    }
}