using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;
using Ticketing.Domain.Model.ProcessSettings;
using Ticketing.Domain.Model.TicketsCartable;
using Ticketing.Domain.Model.Users;

namespace Ticketing.Domain.Model.Tickets
{
    public class Ticket : EntityBase<long>
    {
        public long CustomerId { get; set; }
        public User User { get; set; }
        public long DepartmentId { get; set; }
        public TicketState TicketState { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public string DateTime { get; set; }
        public List<TicketCartable> TicketCartables { get; set; }
        public List<TicketComment.TicketComment> TicketComments { get; set; }

        public Ticket()
        {
        }
        public Ticket(long customerId, long departmentId, TicketState ticketState,
            TicketPriority ticketPriority, string dateTime, TicketComment.TicketComment ticketComment)
        {
            CustomerId = customerId;
            DepartmentId = departmentId;
            TicketState = ticketState;
            TicketPriority = ticketPriority;
            this.DateTime = dateTime;
            if (ticketComment != null)
            {
                TicketComments = new List<TicketComment.TicketComment>();
                TicketComments.Add(ticketComment);
            }
            else
                throw new ArgumentNullException(typeof(TicketComment.TicketComment).Name);
        }

        public void CreateTicketComment(TicketComment.TicketComment ticketComment)
        {
            if ((this.TicketState == TicketState.OpenTicket || TicketState == TicketState.ReOpenTicket)
                && this.CustomerId.ToString() != ticketComment.UserId.ToString())
                this.TicketState = TicketState.TicketResolved;

            if (this.TicketState == TicketState.TicketClosed &&
                this.CustomerId.ToString() == ticketComment.UserId.ToString())
                this.TicketState = TicketState.ReOpenTicket;

            if (this.TicketComments == null)
                TicketComments = new List<TicketComment.TicketComment>();
            else
                this.TicketComments.Add(ticketComment);
        }

        public List<TicketComment.TicketComment> GetTicketComment(long ticketId)
        {
            var myTicketComments = this.TicketComments.Where(x => x.TicketId == ticketId).ToList();
            return myTicketComments;
        }
        public void ChangeStateToOpenTicket(long currentUserId)
        {
            if (this.TicketState == TicketState.ThicketCreated || this.TicketState == TicketState.AssignedTicket
                   && this.CustomerId != currentUserId)
                this.TicketState = TicketState.OpenTicket;

        }
        public void ChangeStateToCloseTicket()
        {
           this.TicketState = TicketState.TicketClosed;
        }
        public void ChangeStateFromCreateTicketToAssignedTicket()
        {
            if (this.TicketState == TicketState.ThicketCreated)
                this.TicketState = TicketState.AssignedTicket;

        }
        public void DeleteTicketCommentForSpecifyTicket(long userId, long ticketId)
        {
            var res = this.TicketComments.Where(x => x.UserId == userId && x.TicketId == ticketId).ToList();
            foreach (var item in res)
            {
                this.TicketComments.Remove(item);
            }
        }


    }
}
