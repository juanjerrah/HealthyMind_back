namespace Diario.Api.Service;

public interface IDiarioRepository
{
    Guid? InserirDiario(Models.Diario diario);
    Models.Diario? ObterDiarioPorId(Guid? id);
    IEnumerable<Models.Diario> ObterDiarios();
    void AtualizarDiario(Models.Diario diario);
    void DeletarDiario(Models.Diario diario);
    void SaveChanges();
}