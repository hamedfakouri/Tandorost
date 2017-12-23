import { Injectable } from '@angular/core';
import { BaseHttp, BaseTicketingService } from './baseHttp';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class SecurityService extends BaseHttp {

    private permission = new Array();
    constructor(public defaultOptions: RequestOptions
        , public cookieService: CookieService, public http: Http, public baseTicketingService: BaseTicketingService) {
        super(defaultOptions, cookieService, http, baseTicketingService);
    }

    getUserPermission(): any {
        debugger
        if (this.permission.length === 0) {
            let headers = new Headers({ "Accept": "application/json" });
            let options = new RequestOptions({ headers: headers });
            return super.get("api/Users", options)
                .map((res: Response) => this.permission = res.json())
                .catch((error: any) =>
                    Observable.throw(error.json().error || 'server error'));
        }
        else {
            let promise = new Promise((resolve, reject) => {
                if (this.permission.length > 0) {
                    resolve(this.permission);
                } else {
                    reject('Oops... something went wrong Permission');
                }
            });
        }
    }

    getAllPermission(): any {
        debugger;
        return this.permission;
    }
}