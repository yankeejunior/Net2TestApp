using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FlightApp.EntityFrameworkCore
{
    public static class FlightAppDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FlightAppDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FlightAppDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
