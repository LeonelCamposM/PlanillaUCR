using Domain.Agreements.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Agreements.EntityMappings
{
    internal class AgreementMap : IEntityTypeConfiguration<Agreement>
    {
        public void Configure(EntityTypeBuilder<Agreement> builder)
        {
            builder.ToTable("Agreement");
            builder.HasKey(p => new { p.employeeEmail, p.employerEmail, p.projectName, p.contractStartDate });
            builder.Property(p => p.mountPerHour)
                 .IsRequired();
            builder.Property(p => p.contractType)
                   .IsRequired();
            builder.Property(p => p.contractFinishDate)
                    .IsRequired();
        }
    }
}
