import { Component } from '@angular/core';
import { Department } from './../../models/departments/department'
import { TicketService } from './../ticketService'
import { DepartmentService } from './../../departments/departmentService'
import { Ticket } from './../../models/tickets/ticket'
import { TicketPriority } from './../../models/tickets/ticketPriority'
import { GetTicketDto } from './../../models/tickets/getTicketDto'

@Component({
    selector: 'ticket',
    styleUrls: ['./ticket.component.css'],
    templateUrl: './ticket.component.html'

})
export class TicketComponent {
    departments = Array<Department>();
    public ticket = new Ticket();
    ticketPriority: Array<TicketPriority>;
    public getTicketDto: Array<GetTicketDto>;

    constructor(private ticketService: TicketService, departmentService: DepartmentService) {

        departmentService.getAll().subscribe(response => {
            this.departments = response;
            debugger;
            this.showTicketGrid();
        });

        this.ticketPriority = new Array<TicketPriority>();
        this.ticketPriority.push(new TicketPriority("High", 1));
        this.ticketPriority.push(new TicketPriority("Medium", 2));
        this.ticketPriority.push(new TicketPriority("Low", 3));
    }

    registerTicket(): void {

        this.ticketService.create(this.ticket).subscribe(data => {
            console.log('success');
            this.showTicketGrid();
        }, error => alert(error));
    }

    showTicketGrid(): any {
        debugger;
        this.ticketService.showTicketGrid().subscribe(response => {
            debugger;
            this.getTicketDto = response;
        });
    }
    getFileName(fileName: string): void {

        this.ticket.AttachmentFileUri = fileName.replace(/"/g, "");
    }
    mapTicketSateAndTicketPriorityEnumToString(ticketDto:Array<GetTicketDto>): void {
        for (var i = 0; i < ticketDto.length; i++) {
            switch (ticketDto[i].TicketState) {
                case 1:
                    ticketDto[i].TicketState = "ThicketCreated";
                    break;
                case 2:
                    ticketDto[i].TicketState = "OpenTicket";
                    break;
                case 3:
                    ticketDto[i].TicketState = "ReOpenTicket";
                    break;
                case 4:
                    ticketDto[i].TicketState = "TicketResolved";
                    break;
                case 5:
                    ticketDto[i].TicketState = "TicketClosed";
                    break;
                case 6:
                    ticketDto[i].TicketState = "AssignedTicket";
                    break;
                default:
                    alert("Wrong State.........");
            }
            switch (this.getTicketDto[i].TicketPriority) {
                case 1:
                    ticketDto[i].TicketPriority = "High";
                    break;
                case 2:
                    ticketDto[i].TicketPriority = "Medium";
                    break;
                case 3:
                    ticketDto[i].TicketPriority = "Low";
                    break;
                default:
                    alert("Wrong Priority.........");
            }
        }
    }

}