using Souccar.Core.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.Settings.Customers.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Abp.Events.Bus;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows.Events;
using Souccar.SaleManagement.CashFlows;
using Souccar.SaleManagement.Settings.Companies.Dto;

namespace Souccar.SaleManagement.Settings.Customers.Services
{
    public class CustomerAppService :
        AsyncSouccarAppService<Customer, CustomerDto, int, FullPagedRequestDto, CreateCustomerDto, UpdateCustomerDto>, ICustomerAppService
    {
        private readonly ICustomerDomainService _customerDomainService;
        public CustomerAppService(ICustomerDomainService customerDomainService) : base(customerDomainService)
        {
            _customerDomainService = customerDomainService;
        }

        public IList<DropdownDto> GetForDropdownAsync()
        {
            var entities = _customerDomainService.GetAll();
            if (entities.Any())
                return ObjectMapper.Map<List<DropdownDto>>(entities.ToList());

            return new List<DropdownDto>();
        }

        public async override Task<CustomerDto> CreateAsync(CreateCustomerDto input)
        {
            var createdCompany = await base.CreateAsync(input);
            EventBus.Default.Trigger(new CustomerCashFlowCreateEventData(
                    createdCompany.BalanceInDollar,
                    createdCompany.BalanceInDinar,
                    TransactionName.InitialBalance,
                    createdCompany.Id,
                    createdCompany.Id,
                    L(LocalizationResource.InitialBalanceFor, input.FullName)
                    ));
            return createdCompany;
        }

        public async override Task<CustomerDto> UpdateAsync(UpdateCustomerDto input)
        {
            var updatedCompany = await base.UpdateAsync(input);
            EventBus.Default.Trigger(new CustomerCashFlowCreateEventData(
                    updatedCompany.BalanceInDollar,
                    updatedCompany.BalanceInDinar,
                    TransactionName.InitialBalance,
                    updatedCompany.Id,
                    updatedCompany.Id,
                    L(LocalizationResource.InitialBalanceFor, input.FullName)
                    ));
            return updatedCompany;
        }
    }
}

