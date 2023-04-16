using Authentication.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Api.Data;

public class AuthContext : DbContext
{
    public AuthContext(DbContextOptions<AuthContext> options) : base(options)
    { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Perfil> Perfis { get; set; }
}