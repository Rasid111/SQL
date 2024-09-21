using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_ef_exam.Configs
{
    internal class CommunityEntityTypeConfiguration : IEntityTypeConfiguration<Entities.Community>
    {
        public void Configure(EntityTypeBuilder<Entities.Community> builder)
        {
            builder
                .HasKey(country => country.Id);
            builder
                .Property(country => country.Name)
                .HasColumnName("CommunityName")
                .HasMaxLength(50);
        }
    }
}
