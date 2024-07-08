namespace Souccar.EntityFrameworkCore.Seed.Host
{
    public class DefaultMaterialsCreator
    {
        private readonly SouccarDbContext _context;

        public DefaultMaterialsCreator(SouccarDbContext context)
        {
            _context = context;
        }

        //public void Create()
        //{
        //    CreateMaterials();
        //}

        //private void CreateMaterials()
        //{
        //    int? tenantId = null;

        //    if (SouccarConsts.MultiTenancyEnabled == false)
        //    {
        //        tenantId = MultiTenancyConsts.DefaultTenantId;
        //    }

        //    AddMaterialIfNotExists("Phosphate", tenantId);
        //    AddMaterialIfNotExists("Silicone", tenantId);
        //}

        //private void AddMaterialIfNotExists(string name, int? tenantId = null)
        //{
        //    if (_context.Materials.IgnoreQueryFilters().Any(s => s.Name.ToLower().Equals(name) && s.TenantId == tenantId))
        //    {
        //        return;
        //    }

        //    _context.Materials.Add(
        //        new Material()
        //        {
        //            Name = name,
        //            Description = name,
        //            LeadTime = 1,
        //            TenantId = tenantId
        //        });
        //    _context.SaveChanges();
        //}
    }
}
