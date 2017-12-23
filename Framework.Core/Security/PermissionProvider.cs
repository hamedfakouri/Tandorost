using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Framework.Core.Security
{
    public class PermissionProvider
    {
        

        public  bool CurrentUserHassPermission(HasPermission hasPermission)
        {
            //var role = ClaimHelper.GetUserRole();
            var userId =long.Parse(ClaimHelper.GetUserId());

            return HasPermisssion(userId, hasPermission);
        }

        private  bool HasPermisssion(long userId, HasPermission hasPermission)
        {

            var resu = _security.GetUserGroup(userId);

            var claims = ClaimHelper.GetUserClaims();
            //var _permissions = new Dictionary<string, List<TicketingPermission>>();

            var _permissions = new Dictionary<string, List<Claim>>();

            //_permissions.Add(userId, claims);

            //if (!_permissions.ContainsKey(role))
            //    return false;

            //return _permissions[role].Any(x => x.Value == hasPermission.Permission.ToString());
            return true;

        }


        //private static bool HasPermisssion(string role, HasPermission hasPermission)
        //{
        //    var claims = ClaimHelper.GetUserClaims();
        //    //var _permissions = new Dictionary<string, List<TicketingPermission>>();

        //    var _permissions = new Dictionary<string, List<Claim>>();

        //    _permissions.Add(role, claims);

        //    if (!_permissions.ContainsKey(role))
        //        return false;

        //    return _permissions[role].Any(x => x.Value == hasPermission.Permission.ToString());

        //}
    }
}
