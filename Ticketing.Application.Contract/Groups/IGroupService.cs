using System;
using System.Collections.Generic;
using Framework.CastleWindsor;
using Framework.Core;
using Framework.Core.Security;
using Ticketing.Domain.Model.Groups;
using Ticketing.Domain.Model.Users;

namespace Ticketing.Application.Contract.Groups
{
    public interface IGroupService:IApplicationService, ISecurity
    {
    }
}
