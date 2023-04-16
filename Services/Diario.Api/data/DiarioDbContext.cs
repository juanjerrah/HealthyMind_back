using Microsoft.EntityFrameworkCore;

namespace Diario.Api.data;

public class DiarioDbContext : DbContext
{
    public DiarioDbContext(DbContextOptions<DiarioDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    public DbSet<Models.Diario> Diarios { get; set; }
    
    
}