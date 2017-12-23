import { Http, Response, Headers, RequestOptions } from '@angular/http'
import { Observable } from 'rxjs/Rx'
import { Injectable } from '@angular/core';
import { UserDto } from './../models/users/users'
import { CookieService } from 'ngx-cookie-service';
import { BaseHttp, BaseTicketingService } from './../../baseHttp'

@Injectable()
export class UsersService extends BaseHttp  {

    user = new UserDto();
    
    constructor(public defaultOptions: RequestOptions
        , public cookieService: CookieService, public http: Http, public baseTicketingService: BaseTicketingService) {
        super(defaultOptions, cookieService, http, baseTicketingService);
    }

    public checkIfUserIsNotRegigteredThenRegisterUser(): Observable<any> {

        this.user.FirstName = "as";
        this.user.LastName = "as";
        let headers = new Headers({"Content-Type": "application/json;domain-model=UserDto" });
        let options = new RequestOptions({ headers: headers });
        return super.post("api/Users", this.user, options)
            .map(res => res.json())
            .catch((error: any) =>
                Observable.throw(error.json().error || 'ServerError'));
    }
}