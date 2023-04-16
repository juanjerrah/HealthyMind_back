using Microsoft.EntityFrameworkCore;

namespace Humor.Api.Data;

public class HumorDbContext : DbContext
{
    public HumorDbContext(DbContextOptions<HumorDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    public DbSet<Models.Humor> Humores { get; set; }
}