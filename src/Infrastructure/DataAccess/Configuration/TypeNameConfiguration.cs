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
    internal class TypeNameConfiguration : IEntityTypeConfiguration<TypeName>
    {
        public void Configure(EntityTypeBuilder<TypeName> builder)
        {
            builder.ToTable("TypeName");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.HasMany(t => t.AnimalType)
                .WithOne(a => a.TypeName)
                .HasForeignKey(a => a.TypeNameId);
        }
    }
}
