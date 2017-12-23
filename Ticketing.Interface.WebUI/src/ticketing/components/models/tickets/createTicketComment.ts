import { ListCommemtAttachment } from './listCommentAttachment';

export class CreateTicketComment {
    TicketId: number;
    Comment: string;
    CommentAttachments: Array<ListCommemtAttachment>;
}
