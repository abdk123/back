using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Souccar.Authorization.Roles;
using Souccar.Authorization.Users;
using Souccar.MultiTenancy;
using Souccar.SaleManagement.Offers;
using Souccar.SaleManagement.Settings.Categories;
using Souccar.SaleManagement.Settings.Companies;
using Souccar.SaleManagement.Settings.Customers;
using Souccar.SaleManagement.Settings.Materials;
using Souccar.SaleManagement.Settings.Stores;
using Souccar.SaleManagement.Settings.Units;
using Souccar.SaleManagement.Stocks;

namespace Souccar.EntityFrameworkCore
{
    public class SouccarDbContext : AbpZeroDbContext<Tenant, Role, User, SouccarDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<UnitSize> UnitSize { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<ClearanceCompany> ClearanceCompany { get; set; }
        public DbSet<TransportCompany> TransportCompany { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Offer> Offer { get; set; }
        public SouccarDbContext(DbContextOptions<SouccarDbContext> options)
            : base(options)
        {
        }
    }
}
