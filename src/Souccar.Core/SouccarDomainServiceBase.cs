using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar
{
    public abstract class SouccarDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected SouccarDomainServiceBase()
        {
            LocalizationSourceName = SouccarConsts.LocalizationSourceName;
        }
    }
}
