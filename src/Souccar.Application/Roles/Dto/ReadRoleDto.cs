using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Souccar.Authorization.Roles;
using Souccar.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.Roles.Dto
{
    public class ReadRoleDto : EntityDto<int>
    {
        [ReadUserInterface(Searchable = true)]
        public string Name { get; set; }
        [ReadUserInterface(Searchable = true)]
        public string DisplayName { get; set; }
        [ReadUserInterface(Searchable = true)]
        public List<string> GrantedPermissions { get; set; }
    }
}
