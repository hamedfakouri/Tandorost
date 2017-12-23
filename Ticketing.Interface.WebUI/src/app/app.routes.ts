import { Routes } from '@angular/router';
import {
    HomeComponent, NoContentComponent

} from './components';
import {  } from './about';

import { DataResolver } from './app.resolver';

export const ROUTES: Routes = [
    { path: '', component: HomeComponent },
    { path: 'index',  component: HomeComponent },
    { path: 'home', component: HomeComponent },
    //{ path: '**', component: NoContentComponent }
  
];
