using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.Settings.Currencies;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public interface IClearanceCompanyDomainService : ISouccarDomainService<ClearanceCompany,int>
    {
        Task<double> GetClearanceCompanyBalance(int? clearanceCompanyId, Currency currency);
    }
}

