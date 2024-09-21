using dotnet_ef_exam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_ef_exam.Configs
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<Entities.User>
    {
        public void Configure(EntityTypeBuilder<Entities.User> builder)
        {
            builder
                .HasKey(user => user.Id);
            builder
                .Property(user => user.Name)
                .HasColumnName("Firstname")
                .HasMaxLength(50);
            builder
                .ToTable(user => user.HasCheckConstraint("CK_User_TooYoung", "Age >= 18"));
        }
    }
}
