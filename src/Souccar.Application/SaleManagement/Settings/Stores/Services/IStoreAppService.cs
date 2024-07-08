using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Souccar.SaleManagement.Settings.Stores.Dto;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Settings.Stores.Services
{
    public interface IStoreAppService : IApplicationService
    {
        PagedResultDto<StoreDto> Read(PagedStoreResultRequestDto input);
        public IList<StoreDto> GetAll();
        Task<StoreDto> GetByIdAsync(int id);
        Task<UpdateStoreDto> GetForEditAsync(int id);
        Task<CreateStoreDto> CreateAsync(CreateStoreDto store);
        Task<UpdateStoreDto> UpdateAsync(UpdateStoreDto store);
        Task DeleteAsync(int id);
    }
}

