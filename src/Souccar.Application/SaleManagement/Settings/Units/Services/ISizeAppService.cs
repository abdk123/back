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
    public interface ISizeAppService : IApplicationService
    {
        PagedResultDto<SizeDto> Read(PagedSizeResultRequestDto input);
        public IList<SizeDto> GetAll();
        Task<SizeDto> GetByIdAsync(int id);
        Task<UpdateSizeDto> GetForEditAsync(int id);
        Task<CreateSizeDto> CreateAsync(CreateSizeDto size);
        Task<UpdateSizeDto> UpdateAsync(UpdateSizeDto size);
        Task DeleteAsync(int id);
    }
}

