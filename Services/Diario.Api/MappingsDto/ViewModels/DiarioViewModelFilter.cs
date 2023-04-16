namespace Diario.Api.MappingsDto.ViewModels;

public class DiarioViewModelFilter
{
    public Guid? Id { get; set; }
    public string? Descricao { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
}