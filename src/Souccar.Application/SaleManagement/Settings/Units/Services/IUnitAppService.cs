using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Souccar.SaleManagement.Settings.Units.Dto;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Units.Services
{
    public interface IUnitAppService : IApplicationService
    {
        PagedResultDto<UnitDto> Read(PagedUnitResultRequestDto input);
        public IList<UnitDto> GetAll();
        Task<UnitDto> GetByIdAsync(int id);
        Task<UpdateUnitDto> GetForEditAsync(int id);
        Task<CreateUnitDto> CreateAsync(CreateUnitDto unit);
        Task<UpdateUnitDto> UpdateAsync(UpdateUnitDto unit);
        Task DeleteAsync(int id);
    }
}

