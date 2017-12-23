import { ListCommemtAttachment } from './listCommentAttachment'

export class TicketComment {
    Id: number;
    CurrntUserId: number;
    Comment: string;
    DateTime: string;
    UserId: number;
    CommentId: number;
    FirstName: string;
    LastName: string;
    CommentAttachments: ListCommemtAttachment;

}