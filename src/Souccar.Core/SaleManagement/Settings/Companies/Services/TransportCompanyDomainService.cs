using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class TransportCompanyDomainService : SouccarDomainService<TransportCompany,int>, ITransportCompanyDomainService
    {
        private readonly IRepository<TransportCompany, int> _transportCompanyRepository;
        public TransportCompanyDomainService(IRepository<TransportCompany, int> transportCompanyRepository):base(transportCompanyRepository)
        {
            _transportCompanyRepository = transportCompanyRepository;
        }
    }
}

