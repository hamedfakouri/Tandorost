import { Directive, ElementRef, Input, Attribute } from '@angular/core';
import { SecurityService } from './../securityService'

@Directive({ selector: '[has-permission]' })
export class HasPermission {
    private attr: any;
    private element: any;
    private resultPermission: string;
    private permission: any;
    private allPermission: Array<string>;
    private res = new Array<string>();
    private result: boolean = false;

    constructor(el: ElementRef, private securityService: SecurityService) {
        debugger;
        this.permission = el.nativeElement.getAttribute('has-permission');
        this.element = el.nativeElement;
        this.allPermission = this.securityService.getAllPermission();
        this.resultPermission = this.permission.toString();
        var target = this.checkPermission(this.resultPermission);

        if (!target) {
            this.element.remove();
        }
    }

    private checkPermission(item): boolean {
        this.allPermission.filter(element => {
            if (element.toLowerCase() === item.toLowerCase()) {
                this.result = true;
            }
        });
        return this.result;
    }



    //constructor(el: ElementRef) {

    //    el.nativeElement.style.backgroundColor = 'yellow';
    //    //.NET WILL DIE! DON'T PRACRICE IT'
    //}
}