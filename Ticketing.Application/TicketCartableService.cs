using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Security;
using Ticketing.Application.Contract.Tickets;
using Ticketing.Application.Contract.TicketsCartable;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Tickets.TicketComment;
using Ticketing.Domain.Model.TicketsCartable;
using Ticketing.Domain.Services.TicketCartableService;

namespace Ticketing.Application
{
    public class TicketCartableService : ITicketCartableService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketCartableRepository _ticketCartableRepository;
        private readonly IValidateTicketAssinedEqualToTrue _validateTicketAssinedEqualToTrue;
        public TicketCartableService(ITicketCartableRepository ticketCartableRepository
            , IValidateTicketAssinedEqualToTrue validateTicketAssinedEqualToTrue
            , ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
            _ticketCartableRepository = ticketCartableRepository;
            _validateTicketAssinedEqualToTrue = validateTicketAssinedEqualToTrue;
        }

        public long ReferralTicket(ReferralTicketCartableDto dto)
        {
            var ticketCartable = new TicketCartable(dto.Description, dto.TicketId, dto.SenderId, dto.DateTime
                , dto.ReciverId, dto.TicketState, _validateTicketAssinedEqualToTrue, ticketAssigned: true);

            _ticketCartableRepository.ReferralTicket(ticketCartable);

            return 0;
        }
        public ListTicketCartableDto GetMyCartable()
        {
            var claimUserId = ClaimHelper.GetUserId();

            if (claimUserId == null)
                throw new SecurityException("You Do Not Have Permission");

            var userId = long.Parse(claimUserId);
            var ticketCartables = _ticketCartableRepository.GetMyTicketsCartables(userId);
            ListTicketCartableDto listTicketCartableDto = new ListTicketCartableDto();
            foreach (var cartable in ticketCartables)
            {
                var comment = cartable.Ticket.TicketComments.Select(x => x.Comment).FirstOrDefault();
                if (comment != null)
                {
                    var ticketDashboardDto = new TicketCartableDTO
                    {
                        Id = cartable.TicketId,
                        Comment = comment,
                        SenderFirstName = cartable.Ticket.User.FirstName,
                        SenderLastName = cartable.Ticket.User.LastName,
                        DateTime = cartable.Ticket.DateTime,
                        TicketState = cartable.Ticket.TicketState.ToString()
                    };
                    listTicketCartableDto.Add(ticketDashboardDto);
                }
            }
            return listTicketCartableDto;
        }

        public ListCommentDto GetMyTicketComment(long ticketId)
        {
            var currentUserId =long.Parse(ClaimHelper.GetUserId());

            var ticketCartable = _ticketCartableRepository.GetMyTicketComment(ticketId);
            ListCommentDto commentDtos = new ListCommentDto();
            foreach (var comment in ticketCartable)
            {
                var attachment = comment.CommentAttachments.SingleOrDefault();

                var commentDto = new CommentDto()
                {

                    Id = comment.Id,
                    CurrntUserId = currentUserId,
                    Comment = comment.Comment,
                    UserId = comment.UserId,
                    FirstName = comment.Users.FirstName,
                    LastName = comment.Users.LastName,
                    DateTime = comment.DateTime,


                };
                if (attachment != null)
                {
                    commentDto.CommentAttachments = new List<CommentAttachmentDto>()
                    {
                        new CommentAttachmentDto()
                        {
                            DateTime = attachment.DateTime,
                            FileName = attachment.FileName,
                            FileUri = attachment.FileUri,
                            Id = attachment.Id
                        }
                    };
                }
                commentDtos.Add(commentDto);
            }
            return commentDtos;
        }
    }
}
