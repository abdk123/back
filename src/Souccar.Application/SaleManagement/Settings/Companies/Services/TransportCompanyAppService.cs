using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Core.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class TransportCompanyAppService :
        AsyncSouccarAppService<TransportCompany, TransportCompanyDto, int, FullPagedRequestDto, CreateTransportCompanyDto, UpdateTransportCompanyDto>, ITransportCompanyAppService
    {
        private readonly ITransportCompanyDomainService _transportCompanyDomainService;
        public TransportCompanyAppService(ITransportCompanyDomainService transportCompanyDomainService) : base(transportCompanyDomainService)
        {
           _transportCompanyDomainService = transportCompanyDomainService;
        }

        public IList<DropdownDto> GetForDropdownAsync()
        {
            var entities = _transportCompanyDomainService.GetAll();
            if (entities.Any())
                return ObjectMapper.Map<List<DropdownDto>>(entities.ToList());

            return new List<DropdownDto>();
        }
    }
}

