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
    public interface IUnitSizeAppService : IApplicationService
    {
        PagedResultDto<UnitSizeDto> Read(PagedUnitSizeResultRequestDto input);
        public IList<UnitSizeDto> GetAll();
        Task<UnitSizeDto> GetByIdAsync(int id);
        Task<UpdateUnitSizeDto> GetForEditAsync(int id);
        Task<CreateUnitSizeDto> CreateAsync(CreateUnitSizeDto unitSize);
        Task<UpdateUnitSizeDto> UpdateAsync(UpdateUnitSizeDto unitSize);
        Task DeleteAsync(int id);
    }
}

