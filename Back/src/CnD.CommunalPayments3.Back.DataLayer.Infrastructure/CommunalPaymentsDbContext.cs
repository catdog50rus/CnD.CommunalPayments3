using System.Diagnostics;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Configuries;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace CnD.CommunalPayments3.Back.DataLayer.Infrastructure;

public class CommunalPaymentsDbContext : DbContext
{
    public DbSet<InvoiceEntity> Invoices { get; set; } = null!;

    public CommunalPaymentsDbContext(DbContextOptions<CommunalPaymentsDbContext> options) : base(options) 
    {
        Database.EnsureCreated();
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=apptest.db");

        optionsBuilder.LogTo
            (
                message => Debug.WriteLine(message),
                new[] { RelationalEventId.CommandExecuting },
                LogLevel.Debug,
                DbContextLoggerOptions.DefaultWithLocalTime
            )
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}