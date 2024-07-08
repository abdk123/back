using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Souccar.Controllers
{
    public abstract class SouccarControllerBase: AbpController
    {
        protected SouccarControllerBase()
        {
            LocalizationSourceName = SouccarConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
