using Souccar.Authorization.Users;
using System;
using System.Threading.Tasks;

namespace Souccar.Notification
{
    public interface IAppNotifier
    {
        Task SendMaterialExpiryDate(User user, string name, DateTime date);
        Task SendCreateOutputRequst(User user, string title);
    }
}
