using System.Linq.Expressions;

namespace Diario.Api.Service;

public interface IDiarioRepository
{
    Guid? InserirDiario(Models.Diario diario);
    Models.Diario? ObterDiarioPorId(Guid? id);
    IEnumerable<Models.Diario> ObterDiarios(Expression<Func<Models.Diario, bool>> predicate, 
        int? start = null, int? length = null);
    void AtualizarDiario(Models.Diario diario);
    void DeletarDiario(Models.Diario diario);
    void SaveChanges();
}