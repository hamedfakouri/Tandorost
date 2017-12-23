import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { SecurityService } from './securityService'
import { Observable } from 'rxjs/Rx';

@Injectable()
export class PermissionResolver implements Resolve<any> {
    constructor(private securityService: SecurityService) { }

    resolve(route: ActivatedRouteSnapshot): Observable<any> {
        debugger;
        return this.securityService.getUserPermission();
    }


}