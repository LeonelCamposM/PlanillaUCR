using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Agreements;
using Domain.Agreements.Entities;
using Domain.Agreements.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Agreements.EntityMappings
{
    public class AgreementMap : IEntityTypeConfiguration<Agreement>
    {
        public void Configure(EntityTypeBuilder<Agreement> builder)
        {
            builder.ToTable("Agreement");

            builder.HasKey(p => new { p.EmployeeEmail, p.EmployerEmail, p.ProjectName, p.ContractDate });

            builder.Property(p => p.MountPerHour)
                 .IsRequired();
            builder.Property(p => p.ContractType)
                   .IsRequired();
            builder.Property(p => p.Duration)
                    .IsRequired();
        }

    }

}
