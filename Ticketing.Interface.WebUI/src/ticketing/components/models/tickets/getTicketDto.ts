import { TicketState } from './ticketState'
export class GetTicketDto {

    constructor(id: number, comment: string, dateTime: string, ticketState: TicketState, ticketPriority: string) {
        debugger;
        this.Id = id;
        this.Comment = comment;
        this.DateTime = dateTime;
        this.TicketPriority = ticketPriority;
       
    }

    Id: number;
    Comment: string;
    DateTime: string;
    TicketState: any;
    TicketPriority: any;
}