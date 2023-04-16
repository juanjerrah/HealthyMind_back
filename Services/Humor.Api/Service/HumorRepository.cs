using System.Linq.Expressions;
using Humor.Api.Data;

namespace Humor.Api.Service;

public class HumorRepository : IHumorRepository
{
    private readonly HumorDbContext _context;

    public HumorRepository(HumorDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Models.Humor> ObterHumores(Expression<Func<Models.Humor, bool>> predicate, 
        int? start = null, int? length = null)
    {
        var query = _context.Set<Models.Humor>().Where(predicate);
        
        if (start is not null && length is not null)
            query = query.Skip(start.Value).Take(length.Value);

        return query.ToList();
    }

    public Models.Humor? ObterHumorPorId(Guid? id) 
        => _context.Humores.FirstOrDefault(x => x.Id.Equals(id));

    public void InserirHumor(Models.Humor humor) 
        => _context.Humores.Add(humor);

    public void AtualizarHumor(Models.Humor humor) 
        => _context.Humores.Update(humor);

    public void DeletarHumor(Models.Humor humor) => _context.Humores.Remove(humor);

    public void SaveChanges() => _context.SaveChanges();
}