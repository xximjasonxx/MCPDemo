using MCPDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MCPDemo.Data;

public class CovidDataDbContext(DbContextOptions<CovidDataDbContext> options) : DbContext(options), IContext
{
    public DbSet<Location> Locations { get; set; }
    public DbSet<Demographic> Demographics { get; set; }
    public DbSet<DateLocationCaseInfo> DateLocationCaseInfo { get; set; }
    public DbSet<MonthYearAggregatedCaseInfo> MonthYearAggregatedCaseInfo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // view mapping
        modelBuilder.Entity<MonthYearAggregatedCaseInfo>()
            .HasNoKey()
            .ToView("MonthYearAggregatedCaseInfo");
        
        // customizations
        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.LocationKey)
                .HasMaxLength(20);
        });

        modelBuilder.Entity<Demographic>(entity =>
        {
            entity.Property(e => e.LocationKey)
                .HasMaxLength(20);
        });

        modelBuilder.Entity<DateLocationCaseInfo>(entity =>
        {
            entity.Property(e => e.LocationKey)
                .HasMaxLength(20);
        });
        
        base.OnModelCreating(modelBuilder);
    }
}

public interface IContext
{
    DbSet<Location> Locations { get; }
    DbSet<Demographic> Demographics { get; }
    DbSet<DateLocationCaseInfo> DateLocationCaseInfo { get; }
    DbSet<MonthYearAggregatedCaseInfo> MonthYearAggregatedCaseInfo { get; }
}