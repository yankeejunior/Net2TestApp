using Abp.Authorization;
using FlightApp.Authorization.Roles;
using FlightApp.Authorization.Users;

namespace FlightApp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
