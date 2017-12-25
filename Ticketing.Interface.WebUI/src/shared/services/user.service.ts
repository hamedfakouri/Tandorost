import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Rx';
import { URLSearchParams } from "@angular/http"
import { BehaviorSubject } from 'rxjs/BehaviorSubject';


@Injectable()
export class UserService  {

    public baseUrl: string = "/API/Account/";
    public Url: string = "";
 
    constructor(public http: Http) {

    }

 
}