using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;

namespace Ticketing.Domain.Model.ProcessSettings
{
    public class ProcessSetting:EntityBase<long>
    {
        public int DepartmentId { get; set; }
        public ProcessSettingValue ProcessSettingValue { get; set; }
    }
}
