using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeN5.Domain.Entities;
using System.Reflection.Emit;

namespace ChallengeN5.Infrastructure.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(50);

            builder.Property(c => c.LastName).HasMaxLength(50);

            builder.Ignore(c => c.FullName);

            builder.Property(c => c.Email).HasMaxLength(255);

            builder.Property(c => c.PhoneNumber).HasMaxLength(50);

            builder.HasMany(e => e.Permissions)
                    .WithOne(p => p.Employee)
                    .HasForeignKey(p => p.EmployeeId);

            builder
                .HasData(
                    new Employee()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Brian",
                        LastName = "Gomez",
                        Email = "brian.gomez@hotmail.com",
                        PhoneNumber = "1111-2222"
                    },
                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        Name = "John",
                        LastName = "Dow",
                        Email = "john.doe@hotmail.com",
                        PhoneNumber = "1111-2222"
                    }
                );
        }

    }
}
