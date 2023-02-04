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
    public class AnimalTypeConfiguration : IEntityTypeConfiguration<AnimalType> 
    {
        public void Configure(EntityTypeBuilder<AnimalType> builder)
        {
            builder.ToTable("AnimalType");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

        }
    }
}
    