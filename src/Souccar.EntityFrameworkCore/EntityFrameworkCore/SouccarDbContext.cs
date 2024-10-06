using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Souccar.Authorization.Roles;
using Souccar.Authorization.Users;
using Souccar.MultiTenancy;
using Souccar.SaleManagement.Settings.Categories;
using Souccar.SaleManagement.Settings.Companies;
using Souccar.SaleManagement.Settings.Customers;
using Souccar.SaleManagement.Settings.Materials;
using Souccar.SaleManagement.Settings.Stores;
using Souccar.SaleManagement.Settings.Units;
using Souccar.SaleManagement.Stocks;
using Souccar.SaleManagement.PurchaseOrders.Deliveries;
using Souccar.SaleManagement.CashFlows.CustomerCashFlows;
using Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows;
using Souccar.SaleManagement.CachFlows.TransportCompanyCachFlows;
using Souccar.SaleManagement.PurchaseOrders.SaleInvoices;
using Souccar.SaleManagement.Logs;
using Souccar.Hr.Employees;
using Souccar.SaleManagement.PurchaseInvoices;
using Souccar.SaleManagement.PurchaseOrders.Offers;
using Souccar.SaleManagement.PurchaseInvoices.Receives;
using Souccar.SaleManagement.PurchaseOrders.SupplierOffers;

namespace Souccar.EntityFrameworkCore
{
    public class SouccarDbContext : AbpZeroDbContext<Tenant, Role, User, SouccarDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitSize> UnitSizes { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerVoucher> CustomerBalances { get; set; }
        public DbSet<ClearanceCompany> ClearanceCompanies { get; set; }
        public DbSet<TransportCompany> TransportCompanies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ClearanceCompanyVoucher> ClearanceCompanyBalances { get; set; }
        public DbSet<TransportCompanyVoucher> TransportCompanyBalances { get; set; }
        public DbSet<PurchaseInvoice> Invoices { get; set; }
        public DbSet<PurchaseInvoiceItem> InvoiceItems { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferItem> OfferItems { get; set; }
        public DbSet<SupplierOffer> SupplierOffers { get; set; }
        public DbSet<SupplierOfferItem> SupplierOfferItems { get; set; }
        public DbSet<Delivery> Deliverys { get; set; }
        public DbSet<DeliveryItem> DeliveryItems { get; set; }
        public DbSet<Receiving> Receivings { get; set; }
        public DbSet<ReceivingItem> ReceivingItems { get; set; }
        public DbSet<CustomerCashFlow> CustomerCashFlows { get; set; }
        public DbSet<ClearanceCompanyCashFlow> ClearanceCompanyCashFlows { get; set; }
        public DbSet<TransportCompanyCashFlow> TransportCompanyCashFlows { get; set; }
        public DbSet<SaleInvoice> SaleInvoices { get; set; }
        public DbSet<OrderLog> OrderLogs { get; set; }
        public DbSet<OrderLogAttribute> OrderLogAttributes { get; set; }
        public DbSet<SaleInvoiceItem> SaleInvoiceItems { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public SouccarDbContext(DbContextOptions<SouccarDbContext> options)
            : base(options)
        {
        }

        
    }
}
