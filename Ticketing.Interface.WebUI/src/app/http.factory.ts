import {XHRBackend, Http, RequestOptions} from "@angular/http";
import { InterceptedHttp } from "./http.interceptor";
import { CookieService } from 'ngx-cookie-service'
import { BaseTicketingService } from './../ticketing/baseTicketingService'

export function httpFactory(xhrBackend: XHRBackend, requestOptions: RequestOptions, cookieService: CookieService, baseService: BaseTicketingService): Http {
    return new InterceptedHttp(xhrBackend, requestOptions, cookieService,baseService); 
}
