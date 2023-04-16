using System.Linq.Expressions;

namespace Humor.Api.Service;

public interface IHumorRepository
{
    IEnumerable<Models.Humor> ObterHumores(Expression<Func<Models.Humor, bool>> predicate, int? start = null,
        int? length = null);

    Models.Humor? ObterHumorPorId(Guid? id);

    void InserirHumor(Models.Humor humor);
    void AtualizarHumor(Models.Humor humor);
    void DeletarHumor(Models.Humor humor);
    void SaveChanges();

}