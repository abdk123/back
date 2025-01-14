using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Souccar.Models.Migrations;
using System;

namespace Souccar.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class MigrationController : SouccarControllerBase
    {
        private IConfiguration _configuration;
        public MigrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public ClearDatabaseOutput Clear(ClearDatabaseInput input)
        {
            if(string.IsNullOrEmpty(input.Password) || input.Password.ToLower() != "2024")
            {
                return new ClearDatabaseOutput("كلمة مرور خاطئة");
            }
            var connectionSerting = _configuration.GetConnectionString("Default");

            var query = "Delete from OrderLogAttributes;" +
                        "Delete from OrderLogs;" +
                        "Delete from ClearanceCompanyCashFlows;" +
                        "Delete from ClearanceCompanyBalances;" +
                        "Delete from TransportCompanyCashFlows;" +
                        "Delete from TransportCompanyBalances;" +
                        "Delete from CustomerCashFlows;" +
                        "Delete from CustomerBalances;" +
                        "Delete from SaleInvoiceItems;" +
                        "Delete from SaleInvoices;" +
                        "Delete from DeliveryItems;" +
                        "Delete from Deliverys;" +
                        "Delete from ReceivingItems;" +
                        "Delete from Receivings;" +
                        "Delete from InvoiceItems;" +
                        "Delete from Invoices;" +
                        "Delete from OfferItems;" +
                        "Delete from Offers;" +
                        "Delete from SupplierOfferItems;" +
                        "Delete from SupplierOffers;" +
                        "Delete from StockHistories;" +
                        "Delete from Stocks;" +
                        "Delete from RejectedMaterials;" +
                        "Delete from Materials;" +
                        "Delete from Sizes;" +
                        "Delete from Stores;" +
                        "Delete from Categories;" +
                        "Delete from Customers;" +
                        "Delete from TransportCompanies;" +
                        "Delete from ClearanceCompanies;" +
                        "Delete from Employees;";

            return new ClearDatabaseOutput(ClearDb(query, connectionSerting));

        }

        private string ClearDb(string query, string connectionSerting)
        {
            var message = "Success";
            using (var connection = new MySqlConnection(connectionSerting))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                var command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    var cmd = query;
                    command.CommandText = cmd;
                    command.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                        message = ex.Message;
                    }
                    catch (Exception rollbackException)
                    {
                        message = rollbackException.Message;
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

            return message;
        }
    }
}
