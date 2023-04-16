using Microsoft.EntityFrameworkCore;

namespace Diario.Api.data;

public class DiarioDbContext : DbContext
{
    public DiarioDbContext(DbContextOptions<DiarioDbContext> options) : base(options)
    {
    }

    public DbSet<Models.Diario> Diarios { get; set; }
}