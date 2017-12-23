import { Injectable } from '@angular/core';
import { ITicketingService } from './../../ITicketingService/ITicketingService';
import { Cartable } from './../models/cartables/cartable';
import { Http, Response,Headers,RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { CookieService } from 'ngx-cookie-service';
import { BaseHttp, BaseTicketingService } from './../../baseHttp';



@Injectable()
export class CartableService extends BaseHttp implements ITicketingService<Cartable> {

    constructor(public defaultOptions: RequestOptions
        , public cookieService: CookieService, public http: Http, public baseTicketingService: BaseTicketingService) {
        super(defaultOptions, cookieService, http, baseTicketingService);
    }

    getById(id): Cartable {
         throw new Error("Not implemented");
    }

    getAll(): Observable<Array<Cartable>> {

        let headers = new Headers({ "accept": "application/json;domain-model=ListTicketCartableDto"});
        let options = new RequestOptions({ headers: headers });


        var res = super.get("api/TicketCartable", options).map((res: Response) => res.json() as Array<Cartable>)
            .catch((error: any) =>
                Observable.throw(error.json().error || 'server error'));
        return res; 
    }

    getMyCartable(): Observable<Array<Cartable>> {

        let headers = new Headers({
            "accept": "application/json;domain-model=ListTicketCartableDto"
        });
        let options = new RequestOptions({ headers: headers });
        var res = super.get("api/TicketCartable", options)
            .map((res: Response) => res.json() as Array<Cartable>)
            .catch((error: any) =>
                Observable.throw(error.json().error || 'server error'));
        return res;

    }

    remove(id): void { throw new Error("Not implemented"); }

    create(item: Cartable): Observable<any> { throw new Error("Not implemented"); }
}