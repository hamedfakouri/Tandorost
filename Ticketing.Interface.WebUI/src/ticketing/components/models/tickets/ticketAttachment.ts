export class TicketAttachment {
    SrcFile: string;
    TicketDescription: string;
    TicketCommentId: any;

    constructor(SrcFile: string, TicketDescription: string, TicketCommentId: any) {
        this.SrcFile = SrcFile;
        this.TicketDescription = TicketDescription;
        this.TicketCommentId = TicketCommentId;
    }
}