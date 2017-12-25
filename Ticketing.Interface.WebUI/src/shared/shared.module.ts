import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { AppServicesModule } from './app.service'
import { LoginComponent } from './components'



@NgModule({
    declarations: [
        
        LoginComponent  
    ],
    imports: [
        CommonModule
        , FormsModule
        , ReactiveFormsModule
        , HttpModule
        , RouterModule
        , AppServicesModule
    ],
    providers: [],
    exports: [
        LoginComponent,
        AppServicesModule


    ]
})
export class SharedModule {

}
