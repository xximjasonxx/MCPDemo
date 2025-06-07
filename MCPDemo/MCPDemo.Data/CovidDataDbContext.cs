using MCPDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MCPDemo.Data;

public class CovidDataDbContextFactory() : IDesignTimeDbContextFactory<CovidDataDbContext>
{
    public CovidDataDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CovidDataDbContext>();
        var clientId = args[0];
        var clientSecret = args[1];
        
        var connectionString = @$"
            Server=tcp:sqlsvr-mcpdemo-eus2-mx01.database.windows.net,1433;Initial Catalog=sqldb-mcpdemo;User ID={clientId};
            Password='{clientSecret}';Persist Security Info=False; MultipleActiveResultSets=False;Connection Timeout=30;
            TrustServerCertificate=False;Authentication='Active Directory Service Principal'";
    
        optionsBuilder.UseSqlServer(connectionString);

        return new CovidDataDbContext(optionsBuilder.Options);
    }
}

public class CovidDataDbContext(DbContextOptions<CovidDataDbContext> options) : DbContext(options), IContext
{
    public DbSet<Location> Locations { get; set; }
    public DbSet<Demographic> Demographics { get; set; }
    public DbSet<DateLocationCaseInfo> DateLocationCaseInfo { get; set; }
    
    public DbSet<MonthYearAggregatedCaseInfo> MonthYearAggregatedCaseInfo { get; set; }
    public DbSet<CountryCasesTotal> CountryCasesTotal { get; set; }
    public DbSet<CountryRegionCasesTotal> CountryRegionCasesTotal { get; set; }
    public DbSet<CountryRegionLocaleCasesTotal> CountryRegionLocaleCasesTotal { get; set; }
    public DbSet<CountryCaseRate> CountryCaseChangeRates { get; set; }
    public DbSet<CountryRegionCaseRate> CountryRegionCaseChangeRates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // view mapping
        modelBuilder.Entity<MonthYearAggregatedCaseInfo>()
            .HasNoKey()
            .ToView("MonthYearAggregatedCaseInfo");
        
        modelBuilder.Entity<CountryCasesTotal>()
            .HasNoKey()
            .ToView("FinalCasesByCountry");

        modelBuilder.Entity<CountryRegionCasesTotal>()
            .HasNoKey()
            .ToView("FinalCasesByCountryRegion");

        modelBuilder.Entity<CountryRegionLocaleCasesTotal>()
            .HasNoKey()
            .ToView("FinalCasesByCountryRegionSubRegion");
        
        modelBuilder.Entity<CountryCaseRate>()
            .HasNoKey()
            .ToView("CountryCasesChangeByMonth");
        
        modelBuilder.Entity<CountryRegionCaseRate>()
            .HasNoKey()
            .ToView("CountryRegionCasesChangeByMonth");
        
        // customizations
        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.LocationKey)
                .HasMaxLength(20);
            
            entity.Property(e => e.CountryCode)
                .HasMaxLength(5);
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
    DbSet<CountryCasesTotal> CountryCasesTotal { get; }
    DbSet<CountryRegionCasesTotal> CountryRegionCasesTotal { get; }
    DbSet<CountryRegionLocaleCasesTotal> CountryRegionLocaleCasesTotal { get; }
    DbSet<CountryCaseRate> CountryCaseChangeRates { get; }
    DbSet<CountryRegionCaseRate> CountryRegionCaseChangeRates { get; }
}