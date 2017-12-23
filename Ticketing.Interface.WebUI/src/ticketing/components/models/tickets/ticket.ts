import {TicketPriority} from './ticketPriority' 
import { TicketState } from './ticketState'


export class Ticket {
    Id: any;
    AttachmentFileUri: string;
    DepartmentId: any;
    TicketPriority: TicketPriority;
    Comment: string;
}