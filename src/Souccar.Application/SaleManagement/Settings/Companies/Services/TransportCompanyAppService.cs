using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Core.Dto;
using System.Collections.Generic;
using System.Linq;
using Abp.Events.Bus;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Events;
using Souccar.SaleManagement.CashFlows;
using System.Threading.Tasks;

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

        public async override Task<TransportCompanyDto> CreateAsync(CreateTransportCompanyDto input)
        {
            var createdCompany = await base.CreateAsync(input);
            EventBus.Default.Trigger(new TransportCompanyCashFlowCreateEventData(
                    createdCompany.BalanceInDollar,
                    createdCompany.BalanceInDinar,
                    TransactionName.InitialBalance,
                    createdCompany.Id,
                    createdCompany.Id,
                    L(LocalizationResource.InitialBalanceFor, input.Name)
                    ));
            return createdCompany;
        }

        public async override Task<TransportCompanyDto> UpdateAsync(UpdateTransportCompanyDto input)
        {
            var updatedCompany = await base.UpdateAsync(input);
            EventBus.Default.Trigger(new TransportCompanyCashFlowCreateEventData(
                    updatedCompany.BalanceInDollar,
                    updatedCompany.BalanceInDinar,
                    TransactionName.InitialBalance,
                    updatedCompany.Id,
                    updatedCompany.Id,
                    L(LocalizationResource.InitialBalanceFor, input.Name)
                    ));
            return updatedCompany;
        }
    }
}

