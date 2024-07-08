using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Souccar.EntityFrameworkCore
{
    public static class SouccarDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SouccarDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SouccarDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
