import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Injectable } from '@angular/core';
import { ITicketingService } from './../../ITicketingService/ITicketingService';
import { Ticket } from './../models/tickets/ticket';
import { Observable } from 'rxjs/Rx';
import { TicketComment } from './../models/tickets/ticketComment';
import { CreateTicketComment } from './../models/tickets/createTicketComment';
import { ListCommemtAttachment } from './../models/tickets/listCommentAttachment';
import { CloseTicketDto } from './../models/tickets/closeTicketDto';
import { CookieService } from 'ngx-cookie-service';
import { BaseHttp, BaseTicketingService } from './../../baseHttp';

@Injectable()
export class TicketService extends BaseHttp implements ITicketingService<Ticket>  {
    private xhr: any;
    closeTicketDto = new CloseTicketDto();

    constructor(public defaultOptions: RequestOptions
        , public cookieService: CookieService, public http: Http, public baseTicketingService: BaseTicketingService) {
        super(defaultOptions, cookieService, http, baseTicketingService);
    }

    getById(id:any): Ticket {
         throw new Error("Not implemented");
    }
    getAll(): Observable<Array<Ticket>> {
         throw new Error("Not implemented"); 
        //this.http.get();
    }

    remove(id: any): void
    { throw new Error("Not implemented"); }

    create(item: Ticket): Observable<any>
    {

        let headers = new Headers({ "Content-Type": "application/json;domain-model=CreateTicketDto" });
        let options = new RequestOptions({ headers: headers });
        return super.post("api/Ticket", item, options)
            .map(res => res.json())
            .catch((error: any) =>
                Observable.throw(error.json().error || 'ServerError'));
    }

    getMyTicketComment(ticketId: number): Observable<TicketComment> {
        let headers = new Headers({ "Accept": "application/json;domain-model=ListCommentDto" });
        let options = new RequestOptions({ headers: headers });
        return super.get("api/TicketCartable/" + ticketId.toString(), options)
            .map((res: Response) => res.json() as Array<TicketComment>)
            .catch((error: any) =>
                Observable.throw(error.json().error || 'server error'));
    }

    writrTicketComment(item: CreateTicketComment): Observable<any> {

        let headers = new Headers({ "Content-Type": "application/json;domain-model=RegisterCommentDto" });
        let options = new RequestOptions({ headers: headers });
        return super.post("api/Ticket", item, options)
            .map(res => res.json())
            .catch((error: any) =>
                Observable.throw(error.json().error || 'ServerError'));
    }

    markAsReadTicket(markAsReadTicket: number): Observable<any> {
        let headers = new Headers({ "Content-Type": "application/json;domain-model=MarkAsReadTicketDto" });
        let options = new RequestOptions({ headers: headers });
        return super.post("api/Ticket", markAsReadTicket, options)
            .map(res => res.json())
            .catch((error: any) =>
                Observable.throw(error.json().error || 'ServerError'));
    }

    showTicketGrid(): Observable<any> {

        let headers = new Headers({ "Content-Type": "application/json;domain-model=ListTicketDto" });
        let options = new RequestOptions({ headers: headers });
        return super.get("api/Ticket", options)
            .map(res => res.json())
            .catch((error: any) =>
                Observable.throw(error.json().error || 'ServerError'));
    }

    changeStateTicketToClose(ticketId: number): Observable<any> {
        this.closeTicketDto.TicketId = ticketId;
        let headers = new Headers({ "Content-Type": "application/json;domain-model=CloseTicketDto" });
        let options = new RequestOptions({ headers: headers });
        return super.post("api/Ticket", this.closeTicketDto, options)
            .map(res => res.json())
            .catch((error: any) =>
                Observable.throw(error.json().error || 'ServerError'));
    }
}