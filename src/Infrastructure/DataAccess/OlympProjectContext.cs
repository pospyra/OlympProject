using DataAccess.Configuration;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OlympProjectContext : DbContext
    {
        public OlympProjectContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Account> DomainAccount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalTypeConfiguration());
        }
    }
}
