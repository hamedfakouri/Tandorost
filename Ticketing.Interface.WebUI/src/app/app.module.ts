import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule, ApplicationRef, APP_INITIALIZER } from '@angular/core';
import { removeNgStyles, createNewHosts, createInputTransfer } from '@angularclass/hmr';
import { RouterModule, PreloadAllModules } from '@angular/router';
import { HttpModule, Http, XHRBackend, RequestOptions, } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BaseTicketingService } from './../ticketing/baseTicketingService';
import { CookieService } from 'ngx-cookie-service';
/*
 * Platform and Environment providers/directives/pipes
 */
import { ENV_PROVIDERS } from './environment';
import { ROUTES } from './app.routes';
// App is our top level component
import { AppComponent } from './components/app.component';
import { APP_RESOLVER_PROVIDERS } from './app.resolver';
import { AppState, InternalStateType } from './app.service';
//import { ModalModule } from 'ngx-bootstrap/modal';
//import { Ng2BootstrapModule } from 'ngx-bootstrap';
import { httpFactory } from "./http.factory";
import {
    HomeComponent, NoContentComponent
    } from './components';
import { UsersService } from './../ticketing/components/users/usersService';
import { TicketingModule } from './../ticketing/ticketing.module';

import '../styles/styles.scss';
import '../styles/headings.css';

// Application wide providers
const APP_PROVIDERS = [
    ...APP_RESOLVER_PROVIDERS,
    AppState
];

type StoreType = {
    state: InternalStateType,
    restoreInputValues: () => void,
    disposeOldHosts: () => void
};


export function usersServiceFactory(usersService: UsersService): Function {
    return () => usersService.checkIfUserIsNotRegigteredThenRegisterUser();
}

/**
 * `AppModule` is the main entry point into Angular2's bootstraping process
 */
@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        HomeComponent,
        NoContentComponent
    ],
    /**
     * Import Angular's modules.
     */
    imports: [
        
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule, ReactiveFormsModule,
        HttpModule,
        //Ng2BootstrapModule,
        //ModalModule.forRoot(),
        RouterModule.forRoot(ROUTES, { useHash: true }),
        TicketingModule
    ],
    exports: [RouterModule],

    /**
     * Expose our Services and Providers into Angular's dependency injection.
     */
    providers: [
        //{
        //    // Provider for APP_INITIALIZER
        //    provide: APP_INITIALIZER,
        //    useFactory: usersServiceFactory,
        //    deps: [UsersService],
        //    multi: true
        //},
        //{
        //    provide: Http,
        //    useFactory: httpFactory,
        //    deps: [XHRBackend, RequestOptions, CookieService, BaseTicketingService]
        //},
        ENV_PROVIDERS,
        APP_PROVIDERS
 
    ]
})
export class AppModule {

    constructor(

        public appRef: ApplicationRef,
        public appState: AppState) { }

    public hmrOnInit(store: StoreType) {
        if (!store || !store.state) {
            return;
        }
        console.log('HMR store', JSON.stringify(store, null, 2));
        /**
         * Set state
         */
        this.appState._state = store.state;
        /**
         * Set input values
         */
        if ('restoreInputValues' in store) {
            let restoreInputValues = store.restoreInputValues;
            setTimeout(restoreInputValues);
        }

        this.appRef.tick();
        delete store.state;
        delete store.restoreInputValues;
    }

    public hmrOnDestroy(store: StoreType) {
        const cmpLocation = this.appRef.components.map((cmp) => cmp.location.nativeElement);
        /**
         * Save state
         */
        const state = this.appState._state;
        store.state = state;
        /**
         * Recreate root elements
         */
        store.disposeOldHosts = createNewHosts(cmpLocation);
        /**
         * Save input values
         */
        store.restoreInputValues = createInputTransfer();
        /**
         * Remove styles
         */
        removeNgStyles();
    }

    public hmrAfterDestroy(store: StoreType) {
        /**
         * Display new elements
         */
        store.disposeOldHosts();
        delete store.disposeOldHosts;
    }

}
