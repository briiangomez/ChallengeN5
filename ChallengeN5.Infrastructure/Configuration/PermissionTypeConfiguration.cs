using ChallengeN5.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace ChallengeN5.Infrastructure.Configuration
{
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.ToTable("PermissionTypes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(50);


            builder
                 .HasData(
                     new PermissionType
                     {
                         Id = Guid.NewGuid(),
                         Name = "Read-Only Access",
                     },
                     new PermissionType
                     {
                         Id = Guid.NewGuid(),
                         Name = "Delete Access",
                     },
                     new PermissionType
                     {
                         Id = Guid.NewGuid(),
                         Name = "Create Access",
                     },
                     new PermissionType
                     {
                         Id = Guid.NewGuid(),
                         Name = "Edit Access",
                     }
                 );
        }
    }
}
