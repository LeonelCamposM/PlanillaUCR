using Domain.Contract.Entities;
using Infrastructure.Core;
using Infrastructure.Contract.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contract
{
    public class ContractDbContext : ApplicationDbContext
    {
        public ContractDbContext(DbContextOptions options, ILogger<ContractDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Contract> Contract { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ContractMap());
        }
    }
}
