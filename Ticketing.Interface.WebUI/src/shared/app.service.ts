import { NgModule } from '@angular/core';

// Account
import {
    UserService
} from './services';
import { BaseService } from './services/base.service';
@NgModule({
    providers: [
        UserService
    ]
})

export class AppServicesModule {

}
