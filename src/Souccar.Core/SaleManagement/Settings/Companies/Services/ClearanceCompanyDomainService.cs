using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public class ClearanceCompanyDomainService : SouccarDomainService<ClearanceCompany, int>, IClearanceCompanyDomainService
    {
        private readonly IRepository<ClearanceCompany, int> _clearanceCompanyRepository;
        public ClearanceCompanyDomainService
            (IRepository<ClearanceCompany, int> clearanceCompanyRepository) : base(clearanceCompanyRepository)
        {
            _clearanceCompanyRepository = clearanceCompanyRepository;
        }

    }
}

