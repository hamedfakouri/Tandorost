import { Component, OnInit } from '@angular/core';
import { TicketService } from './../ticketService'
import { ActivatedRoute, Router } from '@angular/router';
import { TicketComment } from './../../models/tickets/ticketComment'
import { CreateTicketComment } from './../../models/tickets/createTicketComment'
import { ListCommemtAttachment } from './../../models/tickets/listCommentAttachment'
import { MarkAsReadTicket } from './../../models/tickets/markAsReadTicket'

@Component({
    selector: 'ticket-comment',
    styleUrls: ['./ticketComment.component.css'],
    templateUrl: './ticketComment.component.html'

})
export class TicketCommentComponent {
    ticketIdResult: any;
    ticketId: any;
    ticketService: any;
    ticketComment: Array<TicketComment>;
    comment = new CreateTicketComment();
    imgSrc: string = "";
    fileUri: string;
    markAsReadTicket = new MarkAsReadTicket();

    constructor(ticketService: TicketService, public route: ActivatedRoute) {

        this.ticketService = ticketService;
        this.ticketIdResult = this.route.params.subscribe(params => {
            this.ticketId = params['Id'];

            this.markAsReadTicket.TicketId = this.ticketId;
            this.ticketService.markAsReadTicket(this.markAsReadTicket).subscribe(
                data => {
                    debugger;

                    this.getMyTicketComment(this.ticketId);
                    console.log('success');
                },
                error => alert(error)
            );


        });
    }

    writeComment(): void {
        
        this.comment.TicketId = this.ticketId;
        this.comment.CommentAttachments = new Array<ListCommemtAttachment>();
        this.comment.CommentAttachments.push(new ListCommemtAttachment());
        this.comment.CommentAttachments[0].FileUri = this.fileUri;
        this.ticketService.writrTicketComment(this.comment).subscribe(
            data => console.log('success'),
            error => alert(error)
        );
    };

    getFileName(fileName: string): void {

        this.fileUri = fileName.replace(/"/g, "");
    }

    getMyTicketComment(ticketId: number): any {
        this.ticketService.getMyTicketComment(this.ticketId).subscribe(response => {
            this.ticketComment = response;

        });
    }
}