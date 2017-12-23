using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Castle.Components.DictionaryAdapter;
using Castle.MicroKernel.Registration;
using Framework.CastleWindsor;
using Framework.Core;
using Framework.DataAccess.EF;
using Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ticketing.Application.Contract.Tickets;
using Ticketing.Domain.Model.ProcessSettings;
using Ticketing.Domain.Model.Tickets;
using Ticketing.Domain.Model.Tickets.TicketComment;
using Ticketing.Domain.Model.TicketsCartable;
using Ticketing.Domain.Services.TicketServices;
using Ticketing.Persistence.EF;
using Ticketing.Persistence.EF.Repository;
using Ticketing.Persistence.EF.Utils;

namespace Ticketing.Application.UnitTest
{
    [TestClass]
    public class TicketServiceTest
    {
        private readonly ITicketRepository _ticketRepository =
            new TicketRepository(new TicketingDbContext());

        private readonly IProcessSettingRepository _processSettingRepository =
            new ProcessSettingFlow(new TicketingDbContext());

        private readonly ITicketCartableRepository _ticketCartableRepository =
            new TicketCartableRepository(new TicketingDbContext());

        private readonly IUserDepartment _findUserThatHaveLeastOpenTicket =
            new UserDepartment(new UsersRepository(new TicketingDbContext()));

        [TestMethod]
        public void When_InputDataForTicket_Except_SaveTicket()
        {

            #region Arrange

            var ticketAttachments = new List<CommentAttachment>()
            {
                new CommentAttachment(@"D:\", DateTime.Now.ToString())
            };

            var createTicketDto = new CreateTicketDto()
            {
                DepartmentId = 1,

                Comment = "I Have Problem"
                ,
                TicketPriority = TicketPriority.High,
                TicketState = TicketState.ThicketCreated
            };
            #endregion

            #region Act
            //var ticketService = new TicketService(_ticketRepository, _processSettingRepository,
            //    _ticketCartableRepository, _findUserThatHaveLeastOpenTicket);
            //ticketService.RegistTicket(createTicketDto);

            //var mokTicketService = new Mock<ITicketService>();
            //mokTicketService.Setup(x => x.CreateTicketAttachment(dto));

            #endregion

            #region Assert
            var context = new TicketingContextFactory().Create();
            var saveTicket = context.Tickets.First(x => x.TicketPriority == createTicketDto.TicketPriority);
            Assert.AreEqual(saveTicket.TicketPriority, createTicketDto.TicketPriority);
            #endregion

        }

        [TestMethod]
        public void When_InputDataForTicketAttachment_Except_SaveTicketAttachment()
        {
            #region Arrange

            var ticketAttachmentsDto = new List<CommentAttachment>()
            {
                //new CommentAttachment()
                //{
                //    DateTime = DateTime.Now.ToString(),
                //    FileUri  = "D:\\"
                //}
            };
            #endregion

            #region Act
            //var ticketService1 = new TicketService(_ticketRepository, _processSettingRepository,
            //                _ticketCartableRepository, _findUserThatHaveLeastOpenTicket);
           // ticketService1.CreateTicketAttachment(ticketAttachmentsDto, 1);
            #endregion

            #region Assert
            var context = new TicketingContextFactory().Create();
            var ticketAttachment = ticketAttachmentsDto.ToList();
            string srcFile="";
            foreach (var item in ticketAttachment)
            {
                srcFile = item.FileUri;
            }
        
            var saveTicketAttachment = context.CommentAttachments.First(x => x.FileUri == srcFile);
            Assert.AreEqual(saveTicketAttachment.FileUri, srcFile);
            #endregion
        }
    }
}
