using Domain.Contracts.Entities;
using Infrastructure.Core;
using Infrastructure.Contracts.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts
{
    public class ContractDbContext : ApplicationDbContext
    {
        public ContractDbContext(DbContextOptions options, ILogger<ContractDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Contract> Contracts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ContractMap());
        }
    }
}
