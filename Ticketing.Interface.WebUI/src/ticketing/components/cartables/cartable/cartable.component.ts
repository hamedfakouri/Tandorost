import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms'
import { CartableService } from './../cartableService'
import { Cartable } from './../../models/cartables/cartable'
import { TicketService } from './../../tickets/ticketService'


@Component({
    selector: 'cartable',
    styleUrls: ['./cartable.component.css'],
    templateUrl: './cartable.component.html'

})
export class CartableComponent {

    cartable = Array<Cartable>();
    cartableService: any;
    ticketService: TicketService;
    constructor(cartableService: CartableService, ticketService: TicketService) {
        this.cartableService = cartableService;

        this.cartableService.getMyCartable().subscribe(response => {
            this.cartable = response;
            this.ticketService = ticketService;     
        });
    }

    viewMyCartable(): Array<Cartable> {
        var res = this.cartableService.getMyCartable().subscribe(response => {
            this.cartable = response;
        });
        return res;
    }

    changeStateTicketToClose(ticketId: number): void {
        this.ticketService.changeStateTicketToClose(ticketId).subscribe(response => {
            this.cartable = response;
        });
    }

    showMyDepartmentEmployeeForReferral(): any {

    }
}