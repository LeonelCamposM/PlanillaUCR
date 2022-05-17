using Domain.Agreements.Entities;
using Infrastructure.Core;
using Infrastructure.Agreements.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Agreements
{
    public class AgreementDbContext : ApplicationDbContext
    {
        public AgreementDbContext(DbContextOptions options, ILogger<AgreementDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Agreement> Agreements { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AgreementMap());
        }
    }
}
