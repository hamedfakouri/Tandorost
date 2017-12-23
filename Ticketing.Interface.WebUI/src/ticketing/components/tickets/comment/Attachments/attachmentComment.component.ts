import { Component, OnInit } from '@angular/core';
import {TicketService} from './../../ticketService'
import { ActivatedRoute, Router } from '@angular/router';
import { TicketComment } from './../../models/tickets/ticketComment'
import { ListCommemtAttachment } from './../../../models/tickets/listCommentAttachment'


@Component({
    selector: 'attachment-comment',
    templateUrl: './attachmentComment.component.html'

})
export class CommentAttachmentComponent {
    ticketCommentIdResult: any;
    ticketCommentId: any;
    ticketService: any;

    commnetAttachment: ListCommemtAttachment;

    constructor(ticketService: TicketService, public route: ActivatedRoute) {
        this.ticketService = ticketService;

        this.ticketCommentIdResult = this.route.params.subscribe(params => {
            this.ticketCommentId = params['Id'];

            this.ticketService.getCommentAttachment(this.ticketCommentId).subscribe(response => {
                this.commnetAttachment = response;
            });
        });
    }
}