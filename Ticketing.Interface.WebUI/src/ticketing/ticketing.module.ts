import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { RouterModule } from '@angular/router';
//import { ModalModule } from 'ngx-bootstrap/modal';
import {
    TicketComponent,
    TicketService, DepartmentService, DepartmentListComponent,
    FileUploadComponent, CartableService, CartableComponent,
    TicketCommentComponent, CommentAttachmentComponent, AssignPermissionComponent
    , TicketingHomeComponent, TicketingNavComponent
} from './components';
import { AccordionModule, TooltipModule } from 'extentions';
import { UsersService } from './../ticketing/components/users/usersService';
import { BaseTicketingService } from './baseTicketingService';
import { CookieService } from 'ngx-cookie-service';
import { SecurityService } from './securityService';
import { HasPermission } from './directives/hasPermission';
import { PermissionResolver } from './permissionResolver'
console.log('`TicketingModule` bundle loaded asynchronously');


export const ticketingRoutes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    //{ path: 'home', component: TicketingHomeComponent },
    { path: 'ticket', component: TicketComponent },
    //{ path: 'cartable', component: CartableComponent },
    //{ path: 'assignPermission', component: AssignPermissionComponent },
    { path: 'ViewTicketComments/:Id', component: TicketCommentComponent },
];

@
NgModule({
    declarations: [
        HasPermission,
        TicketingNavComponent,
        TicketingHomeComponent,
        CommentAttachmentComponent,
        AssignPermissionComponent,
        TicketComponent,
        DepartmentListComponent,
        FileUploadComponent, CartableComponent,
        TicketCommentComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule.forRoot([
            {
                path: 'cartable',
                component: CartableComponent,
                resolve: {
                    permission: PermissionResolver
                }
            },
            {
                path: 'home',
                component: TicketingHomeComponent,
                resolve: {
                    permission: PermissionResolver
                }
            }
        ]),
        RouterModule.forChild(ticketingRoutes)

    ],
    providers: [
        PermissionResolver,
        SecurityService,
        UsersService,
        CookieService,
        BaseTicketingService,
        TicketService,
        DepartmentService,
        CartableService,
    ],
    exports: [
        TicketComponent,
        DepartmentListComponent,
        FileUploadComponent, CartableComponent,
        TicketCommentComponent
    ]
})
export class TicketingModule {
    permission = new Array<string>();

    public static routes = ticketingRoutes;
    constructor(private usersService: UsersService, private securityService: SecurityService) {
        this.usersService.checkIfUserIsNotRegigteredThenRegisterUser().subscribe(
            data => console.log('success'),
            error => alert(error)
        );
    }

  
    
}
