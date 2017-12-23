import { Injectable } from '@angular/core';
import { ITicketingService } from './../../ITicketingService/ITicketingService';
import { Department } from './../models/departments/department';
import { Observable } from 'rxjs/Rx';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { BaseHttp, BaseTicketingService } from './../../baseHttp';
import { CookieService } from 'ngx-cookie-service';
@Injectable()
export class DepartmentService extends BaseHttp implements ITicketingService<Department>  {

    constructor(public defaultOptions: RequestOptions
        , public cookieService: CookieService, public http: Http, public baseTicketingService: BaseTicketingService) {
        super(defaultOptions, cookieService, http, baseTicketingService);
    }

    getById(id: any): Department
    { throw new Error("Not implemented"); }

    getAll(): Observable<Array<Department>> {
        let headers = new Headers({ "accept": "application/json;domain-model=DepartmentList" });
        let options = new RequestOptions({ headers: headers });

        var res = super.get("api/Department", options)
            .map((res: Response) => res.json() as Array<Department>)
            .catch((error: any) =>
                Observable.throw(error.json().error || 'server error'));
        return res;
        
    }

    remove(id): void
    { throw new Error("Not implemented"); }

    create(item: Department): Observable<any>
    { throw new Error("Not implemented"); }
}