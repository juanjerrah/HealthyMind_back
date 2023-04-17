using Humor.Api.Models.Enums;

namespace Humor.Api.MappingsDto.ViewModels;

public class HumorViewModelGrid
{
    public Guid Id { get; set; }
    public string TituloHumor { get; set; }
    public string DescricaoHumor { get; set; }
    public ETipoHumor TipoDoHumor { get; set; }
    public bool PermiteVisualizacao { get; set; }
    public DateTimeOffset DataInclusao { get; set; }
}