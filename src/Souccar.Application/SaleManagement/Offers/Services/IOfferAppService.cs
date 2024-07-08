using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Souccar.SaleManagement.Offers.Dto;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Offers.Services
{
    public interface IOfferAppService : IApplicationService
    {
        PagedResultDto<OfferDto> Read(PagedOfferResultRequestDto input);
        public IList<OfferDto> GetAll();
        Task<OfferDto> GetByIdAsync(int id);
        Task<UpdateOfferDto> GetForEditAsync(int id);
        Task<CreateOfferDto> CreateAsync(CreateOfferDto offer);
        Task<UpdateOfferDto> UpdateAsync(UpdateOfferDto offer);
        Task DeleteAsync(int id);
    }
}

