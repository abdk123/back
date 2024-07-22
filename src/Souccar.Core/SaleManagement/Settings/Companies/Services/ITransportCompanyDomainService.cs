using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.Settings.Currencies;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Settings.Companies.Services
{
    public interface ITransportCompanyDomainService : ISouccarDomainService<TransportCompany,int>
    {
        Task<double> GetTransportCompanyBalance(int? transportCompanyId, Currency currency);
    }
}

