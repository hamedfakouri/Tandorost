using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security;
using System.Security.Claims;
using System.Web.Http;
using Castle.DynamicProxy;
using Framework.Core;
using Framework.Core.Security;

namespace Framework.CastleWindsor
{
    public class SecurityInterceptor : IInterceptor
    {
        private readonly ISecurity _security;
        public SecurityInterceptor(ISecurity security)
        {
            _security = security;
        }
        public void Intercept(IInvocation invocation)
        {
            var permission = GetPermission(invocation.Method);

            if (permission != null)
                CheckCurrentUserHasPermission(permission);
            else
                CkeckIfNoPermPermissionNeeded(invocation);

            invocation.Proceed();
        }

        private void CkeckIfNoPermPermissionNeeded(IInvocation invocation)
        {
            var ignorePermission = invocation.Method.GetCustomAttributes<IgnorePermission>(true)
                .FirstOrDefault();

            if (ignorePermission == null)
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        private void CheckCurrentUserHasPermission(HasPermission hasPermission)
        {
            if (!CurrentUserHasPermission(hasPermission))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
        private HasPermission GetPermission(MethodInfo method)
        {
            var attribute = method.GetCustomAttributes<HasPermission>(true).FirstOrDefault();
            return attribute;
        }
        public bool CurrentUserHasPermission(HasPermission hasPermission)
        {
            //var role = ClaimHelper.GetUserRole();
            var userId = long.Parse(ClaimHelper.GetUserId());

            return HasPermisssion(userId, hasPermission);
        }
        private bool HasPermisssion(long userId, HasPermission hasPermission)
        {
            bool result = false;
            var permission = hasPermission.Permission;
            var permissions = _security.GetUserGroup(userId);
            foreach (var userPermission in permissions)
            {
                if (permission == userPermission)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
