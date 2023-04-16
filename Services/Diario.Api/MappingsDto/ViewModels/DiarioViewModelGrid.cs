namespace Diario.Api.MappingsDto.ViewModels;

public class DiarioViewModelGrid
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public DateTimeOffset DataInclusao { get; set; }
    public DateTimeOffset DataAlteracao { get; set; }
}