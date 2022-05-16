using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Contracts;
using Domain.Contracts.Entities;
using Domain.Contracts.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts.EntityMappings
{
    public class ContracttMap : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contract");

            builder.HasKey(p => p.EmployeeEmail);
            builder.HasKey(p => p.ProjectEmail);
            builder.HasKey(p => p.ProjectName);

            builder.Property(p => p.Project_Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.MountPerHour)
                 .IsRequired();

            builder.Property(p => p.TypeOfContract)
                   .IsRequired();
            builder.Property(p => p.Date)
                   .IsRequired();
            builder.Property(p => p.Duration)
                    .IsRequired();
        }

    }

}
