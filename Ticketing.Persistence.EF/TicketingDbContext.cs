using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Model;
using Ticketing.Domain.Model.Departments;
using Ticketing.Domain.Model.Groups;
using Ticketing.Domain.Model.Log;
using Ticketing.Domain.Model.ProcessSettings;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Tickets.TicketComment;
using Ticketing.Domain.Model.TicketsCartable;
using Ticketing.Domain.Model.Users;
using Ticketing.Persistence.EF.Utils;

namespace Ticketing.Persistence.EF
{
    public class TicketingDbContext:DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ProcessSetting> ProcessSettings { get; set; }
        public DbSet<TicketCartable> TicketCartables { get; set; }
        public DbSet<TicketComment> TicketComments { get; set; }
        public DbSet<LogTicket> LogTickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<CommentAttachment> CommentAttachments { get; set; }

        public TicketingDbContext(DbConnection connection,bool contextOwnsConnection=false)
            :base(connection,contextOwnsConnection)
        {
            Database.SetInitializer<TicketingDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        //public TicketingDbContext() : base("DBConnection")
        //{

        //}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(TicketingDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
