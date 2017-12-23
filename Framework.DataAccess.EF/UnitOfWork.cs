using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EntityFramework.Audit;
using EntityFramework.Extensions;
using Framework.Core;
using Ticketing.Domain.Model.Log;
using Ticketing.Domain.Model.TicketsCartable;

namespace Framework.DataAccess.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private DbContextTransaction _transaction;
        private AuditLogger _audit;
        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }
        public void Begin()
        {
            _transaction = _dbContext.Database.BeginTransaction();

            AuditConfiguration.Default.DefaultAuditable = true;
            _audit = _dbContext.BeginAudit();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();

             RegistrLog();
             
            _transaction.Commit();
        }
        public void RollBack()
        {
            _transaction.Rollback();
        }

        private void RegistrLog()
        {
            var log = _audit.LastLog;
            var ticket = log.Entities.Where(x => x.EntityType.Name == typeof(TicketCartable).Name);

            foreach (var item in ticket)
            {
                var ticketDashboard = (TicketCartable)item.Current;
                if (ticketDashboard != null)
                {
                    int auditAction = (int)item.Action;
                    LogTicket logTicket = new LogTicket(ticketDashboard.TicketId,
                        ticketDashboard.DateTime, ticketDashboard.ReciverId,
                        ticketDashboard.Ticket.TicketState, auditAction);

                    _dbContext.Set<LogTicket>().Add(logTicket);
                }
            }
            // log.ToXml(new XmlTextWriter(@"d:\EntityLog.xml", Encoding.UTF8));
            _dbContext.SaveChanges();
        }
    }
}
