using Diario.Api.data;

namespace Diario.Api.Service;

public class DiarioRepository : IDiarioRepository
{
    private readonly DiarioDbContext _context;

    public DiarioRepository(DiarioDbContext context)
    {
        _context = context;
    }

    public Guid? InserirDiario(Models.Diario diario)
    {
        _context.Diarios.Add(diario);
        return diario.Id;
    }

    public Models.Diario? ObterDiarioPorId(Guid? id) 
        => _context.Diarios.FirstOrDefault(x => x.Id.Equals(id));

    public IEnumerable<Models.Diario> ObterDiarios()
    {
        return _context.Diarios.ToList();
    }


    public void AtualizarDiario(Models.Diario diario) => _context.Diarios.Update(diario);

    public void DeletarDiario(Models.Diario diario)
    {
        _context.Diarios.Remove(diario);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}