using Humor.Api.Models.Enums;

namespace Humor.Api.MappingsDto.ViewModels;

public class HumorViewModelFilter
{
    public Guid? Id { get; set; }
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public ETipoHumor? TipoHumor { get; set; }
    public bool? PermiteVisualizacao { get; set; }
    public DateTimeOffset? DataInicio { get; set; }
    public DateTimeOffset? DataFim { get; set; }
    
}