using System.Linq.Expressions;
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

    public IEnumerable<Models.Diario> ObterDiarios(Expression<Func<Models.Diario, bool>> predicate,
        int? start = null, int? length = null)
    {
        var query = _context.Set<Models.Diario>().Where(predicate);
        
        if (start is not null && length is not null)
            query = query.Skip(start.Value).Take(length.Value);
        
        return query.ToList();
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