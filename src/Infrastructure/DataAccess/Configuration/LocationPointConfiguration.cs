using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class LocationPointConfiguration : IEntityTypeConfiguration<LocationPoint>
    {
        public void Configure(EntityTypeBuilder<LocationPoint> builder)
        {
            builder.ToTable("LocationPoint");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
        }
    }
}