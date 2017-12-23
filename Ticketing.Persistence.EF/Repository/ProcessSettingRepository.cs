using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Ticketing.Domain.Model.ProcessSettings;
using Ticketing.Domain.Model.Tickets;


namespace Ticketing.Persistence.EF.Repository
{
    public class ProcessSettingFlow : IProcessSettingRepository
    {
        private readonly TicketingDbContext _context;

        public ProcessSettingFlow(TicketingDbContext context)
        {
            _context = context;
        }

        public void CreateProcessSetting(ProcessSetting processSetting)
        {
            throw new NotImplementedException();
        }

        public void EditProcessSetting(ProcessSetting processSetting)
        {
            throw new NotImplementedException();
        }

        public void DeleteProcessSetting(ProcessSetting processSetting)
        {
            throw new NotImplementedException();
        }

        public List<ProcessSetting> GetAllProcessSetting()
        {
            throw new NotImplementedException();
        }
        public ProcessSetting GetSettingFlow(long departmentId)
        {
            return _context.ProcessSettings.SingleOrDefault(x => x.DepartmentId == departmentId);
        }

      
    }
}
