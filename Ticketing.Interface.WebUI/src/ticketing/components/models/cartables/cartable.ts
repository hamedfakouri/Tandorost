import { TicketState } from './../../models/tickets/ticketState'
import { TicketAttachment } from './../../models/tickets/ticketAttachment'


export class Cartable {
    Id:number;
    Comment: string;
    SenderFirstName: string;
    SenderLastName: string;
    DateTime: string;
    TicketState: TicketState;

    constructor(Id:number,Comment: string, SenderFirstName: string, SenderLastName: string, DateTime: string, TicketState: TicketState) {
        this.Id = Id;
        this.Comment = Comment;
        this.SenderFirstName = SenderFirstName;
        this.SenderLastName = SenderLastName;
        this.DateTime = DateTime;
        this.TicketState = TicketState;
    }
}