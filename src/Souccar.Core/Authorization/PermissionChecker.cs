using Abp.Authorization;
using Souccar.Authorization.Roles;
using Souccar.Authorization.Users;

namespace Souccar.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
