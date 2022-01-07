using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Tecsmart.Suporte.EntityFrameworkCore
{
    public static class SuporteDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SuporteDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString, p => p.SetPostgresVersion(new Version(13, 2)));
        }

        public static void Configure(DbContextOptionsBuilder<SuporteDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection, p => p.SetPostgresVersion(new Version(13, 2)));
        }
    }
}
