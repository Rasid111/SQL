using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_ef_exam.Configs
{
    internal class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Entities.Country>
    {
        public void Configure(EntityTypeBuilder<Entities.Country> builder)
        {
            builder
                .HasMany(c => c.Users)
                .WithOne(u => u.Country);
            builder
                .HasKey(country => country.Id);
            builder
                .Property(country => country.Name)
                .HasColumnName("CountryName")
                .HasMaxLength(50);
        }
    }
}
