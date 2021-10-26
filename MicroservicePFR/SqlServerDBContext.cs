using MicroservicePFR.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace MicroservicePFR
{
    public class SqlServerDBContext : DbContext
    {
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Favourite> Favourite { get; set; }
        public SqlServerDBContext(DbContextOptions<SqlServerDBContext> options): base(options)
        {
        }
        
    }
}
