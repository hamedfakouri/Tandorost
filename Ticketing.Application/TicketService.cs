using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Framework.Core.Security;
using Ticketing.Application.Contract.Tickets;
using Ticketing.Domain.Model.ProcessSettings;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Tickets.TicketComment;
using Ticketing.Domain.Model.TicketsCartable;
using Ticketing.Domain.Services.TicketServices;
using System.Web;
using Framework.Core.GlobalExtentions;
using Ticketing.Application.Contract.Users;
using Ticketing.Domain.Model.Users;

namespace Ticketing.Application
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IProcessSettingRepository _processSettingRepository;
        private readonly ITicketCartableRepository _ticketCartableRepository;
        private readonly IUserDepartment _findUserThatHaveLeastOpenTicket;

        public TicketService(ITicketRepository ticketRepository, IProcessSettingRepository processSettingRepository
            , ITicketCartableRepository ticketCartableRepository, IUserDepartment findUserThatHaveLeastOpenTicket)
        {
            _ticketRepository = ticketRepository;
            _processSettingRepository = processSettingRepository;
            _ticketCartableRepository = ticketCartableRepository;
            _findUserThatHaveLeastOpenTicket = findUserThatHaveLeastOpenTicket;
        }

        public void RegistTicket(CreateTicketDto dto)
        {
            var userId = long.Parse(ClaimHelper.GetUserId());

            if (dto.AttachmentFileUri != null)
            {
                dto.TicketAttachments = new List<CommentAttachment>()
                {
                    new CommentAttachment(null,dto.AttachmentFileUri)
                };
            }

            var ticketComment = new TicketComment(dto.Comment, DateTime.Now.ToPersianLongDateTime(), dto.TicketAttachments
                , userId);

            var ticket = new Ticket(userId, dto.DepartmentId
                , TicketState.ThicketCreated
                , dto.TicketPriority, DateTime.Now.ToPersianLongDateTime(), ticketComment);

            var ticketId = _ticketRepository.CreateTicket(ticket);

            var deparmentFlow = _processSettingRepository.GetSettingFlow(dto.DepartmentId);
            if (deparmentFlow.ProcessSettingValue == ProcessSettingValue.Automatic)
            {
                var ticketCartable = new TicketCartable("System Sender", dto.DepartmentId
                    , _findUserThatHaveLeastOpenTicket, 0, DateTime.Now.ToPersianLongDateTime(), ticketId
                    , ticketAssigned: true);

                ticket.ChangeStateFromCreateTicketToAssignedTicket();
                _ticketCartableRepository.ReferralTicket(ticketCartable);
            }
        }
        public void WriteTicketComment(RegisterCommentDto dto)
        {
            if (dto.CommentAttachments[0].FileUri != null)
            {
                dto.CommentAttachments = new List<CommentAttachment>()
                {
                    new CommentAttachment(null,dto.CommentAttachments[0].FileUri)
                };
            }
            else
            {
                dto.CommentAttachments = null;
            }
            var ticket = _ticketRepository.GetBy(dto.TicketId);
            var currentUserId = ClaimHelper.GetUserId();

            var ticketComment = new TicketComment(dto.Comment, DateTime.Now.ToPersianLongDateTime(), dto.CommentAttachments, Int64.Parse(currentUserId.ToString()));
            ticket.CreateTicketComment(ticketComment);
        }
        public async Task<ListTicketDto> GetMyTicket()
        {
            var userId = long.Parse(ClaimHelper.GetUserId());
            var comments = await _ticketRepository.GetMyTicket(userId);
            var ticketList = new ListTicketDto();
            foreach (var ticket in comments)
            {
                var commnentDto = new TicketDto()
                {
                    Id = ticket.Id,
                    Comment = ticket.TicketComments.Select(x => x.Comment).FirstOrDefault(),
                    DateTime = ticket.DateTime,
                    TicketState = ticket.TicketState.ToString(),
                    TicketPriority = ticket.TicketPriority.ToString(),
                };
                ticketList.Add(commnentDto);
            }

            return ticketList;
        }

        public void Delete(long ticketId)
        {
            _ticketRepository.Delete(ticketId);
        }

        public void DeleteComment(long ticketId)
        {
            var ticket = _ticketRepository.GetBy(ticketId);
            ticket.DeleteTicketCommentForSpecifyTicket(1, ticket.Id);
        }

        public List<Ticket> GetTicketsForCustomer(long userId)
        {
            var currentUserId = ClaimHelper.GetUserId();
            return _ticketRepository.GetTicketsForCustomer(Int64.Parse(currentUserId));

        }

        public void MarkAsOpenTicketInCartable(long ticketId)
        {
            var currentUserId = ClaimHelper.GetUserId();

            var ticket = _ticketRepository.GetBy(ticketId);
            ticket.ChangeStateToOpenTicket(Int64.Parse(currentUserId));
        }

        private bool CheckFile(HttpPostedFile postedFile)
        {
            int MinFileSize = 10000;//Reading This Value From Config Table
            int MaxFileSize = 1000000;//Reading This Value From Config Table
            if (postedFile.ContentLength < MinFileSize || postedFile.ContentLength > MaxFileSize)
                return false;

            var extensionFile = System.IO.Path.GetExtension(postedFile.FileName);
            switch (extensionFile.ToLower())
            {
                case ".gif":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                case ".png":
                    return true;
                default:
                    return false;
            }
        }

        public string GetUploadTicketAttachment()
        {
            var httpRequest = HttpContext.Current.Request;
            string fileName = null;
            if (httpRequest.Files.Count > 0)
            {

                foreach (string file in httpRequest.Files)
                {
                    if (!CheckFile(httpRequest.Files[file]))
                        throw new ArgumentOutOfRangeException("The Extension File Is Not Valid!!!");

                    string phisicallAddress = HttpContext.Current.Server.MapPath(httpRequest.ApplicationPath) + "/AttachmentFiles/";
                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null)
                    {
                        fileName = System.IO.Path.GetFileName(postedFile.FileName);
                        fileName = DateTime.Now.ToPersianLongDateTime() + fileName;
                        phisicallAddress = phisicallAddress + fileName;
                        fileName = "AttachmentFiles/" + fileName;
                        postedFile.SaveAs(phisicallAddress);
                    }
                }
            }
            return fileName;
        }

        public void ChangeStateToCloseTicket(long id)
        {
            var ticket = _ticketRepository.GetBy(id);
            ticket.ChangeStateToCloseTicket();
        }
    }
}
