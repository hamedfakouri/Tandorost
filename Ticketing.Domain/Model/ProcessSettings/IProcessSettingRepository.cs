using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Ticketing.Domain.Model.Users;


namespace Ticketing.Domain.Model.ProcessSettings
{
    public interface IProcessSettingRepository: IRepository
    {
        void CreateProcessSetting(ProcessSetting processSetting);
        void EditProcessSetting(ProcessSetting processSetting);
        void DeleteProcessSetting(ProcessSetting processSetting);
        List<ProcessSetting> GetAllProcessSetting();
        ProcessSetting GetSettingFlow(long departmentId);

    }
}
