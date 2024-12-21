using Souccar.SaleManagement.Settings.Companies.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Core.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Events.Bus;
using Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Events;
using Souccar.SaleManagement.CashFlows;
using Souccar.SaleManagement.PurchaseInvoices.Receives;
using Souccar.SaleManagement.Settings.Currencies;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Events;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class ClearanceCompanyAppService :
        AsyncSouccarAppService<ClearanceCompany, ClearanceCompanyDto, int, FullPagedRequestDto, CreateClearanceCompanyDto, UpdateClearanceCompanyDto>, IClearanceCompanyAppService
    {
        private readonly IClearanceCompanyDomainService _clearanceCompanyDomainService;
        public ClearanceCompanyAppService(IClearanceCompanyDomainService clearanceCompanyDomainService) : base(clearanceCompanyDomainService)
        {
            _clearanceCompanyDomainService = clearanceCompanyDomainService;
        }

        public IList<DropdownDto> GetForDropdownAsync()
        {
            var entities = _clearanceCompanyDomainService.GetAll();
            if (entities.Any())
                return ObjectMapper.Map<List<DropdownDto>>(entities.ToList());

            return new List<DropdownDto>();
        }

        public async override Task<ClearanceCompanyDto> CreateAsync(CreateClearanceCompanyDto input)
        {
            var createdCompany = await base.CreateAsync(input);
            EventBus.Default.Trigger(new ClearanceCompanyCashFlowCreateEventData(
                    createdCompany.BalanceInDollar,
                    createdCompany.BalanceInDinar,
                    TransactionName.InitialBalance,
                    createdCompany.Id,
                    createdCompany.Id,
                    L(LocalizationResource.InitialBalanceFor, input.Name)
                    ));
            return createdCompany;
        }

        public async override Task<ClearanceCompanyDto> UpdateAsync(UpdateClearanceCompanyDto input)
        {
            var updatedCompany = await base.UpdateAsync(input);
            EventBus.Default.Trigger(new ClearanceCompanyCashFlowCreateEventData(
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

