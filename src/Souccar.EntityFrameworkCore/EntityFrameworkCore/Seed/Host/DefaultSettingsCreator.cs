using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Configuration;
using Abp.Localization;
using Abp.MultiTenancy;
using Abp.Net.Mail;
using Souccar.Configuration;

namespace Souccar.EntityFrameworkCore.Seed.Host
{
    public class DefaultSettingsCreator
    {
        private readonly SouccarDbContext _context;

        public DefaultSettingsCreator(SouccarDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            int? tenantId = null;

            if (SouccarConsts.MultiTenancyEnabled == false)
            {
                tenantId = MultiTenancyConsts.DefaultTenantId;
            }

            // Emailing
            AddSettingIfNotExists(EmailSettingNames.DefaultFromAddress, "admin@mydomain.com", tenantId);
            AddSettingIfNotExists(EmailSettingNames.DefaultFromDisplayName, "mydomain.com mailer", tenantId);
            //AddSettingIfNotExists(AppSettingNames.Srss.Url, "http://localhost/reportserver", tenantId);
            //AddSettingIfNotExists(AppSettingNames.Srss.Folder, "Reports", tenantId);
            //AddSettingIfNotExists(AppSettingNames.Hcpc.ExpiryDurationNotify, "30", tenantId);

            // Languages
            AddSettingIfNotExists(LocalizationSettingNames.DefaultLanguage, "ar", tenantId);
        }

        private void AddSettingIfNotExists(string name, string value, int? tenantId = null)
        {
            if (_context.Settings.IgnoreQueryFilters().Any(s => s.Name == name && s.TenantId == tenantId && s.UserId == null))
            {
                return;
            }

            if (_context.Users.IgnoreQueryFilters().Any(s => s.TenantId == tenantId && s.Id == 1)
                && !_context.Settings.IgnoreQueryFilters().Any(s => s.Name == name && s.TenantId == tenantId && s.UserId == 1))
            {
                _context.Settings.Add(new Setting(tenantId, 1, name, value));
            }

            _context.Settings.Add(new Setting(tenantId, null, name, value));
            _context.SaveChanges();
        }
    }
}
