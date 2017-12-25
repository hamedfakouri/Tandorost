/**
 * Angular 2 decorators and services
 */
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';

/**
 * App Component
 * Top Level Component
 */
@Component({
    selector: 'login',
    encapsulation: ViewEncapsulation.None,
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
   
    
    constructor( private router: Router) {
            console.log('login...');

    }

    public ngOnInit() {
    
    }
  
}