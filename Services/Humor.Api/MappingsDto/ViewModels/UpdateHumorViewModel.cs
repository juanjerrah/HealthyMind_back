using System.ComponentModel.DataAnnotations;
using Humor.Api.Models.Enums;

namespace Humor.Api.MappingsDto.ViewModels;

public class UpdateHumorViewModel
{
    [Required(ErrorMessage = "Id do humor é obrigatório")]
    public Guid Id { get; set; }
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public ETipoHumor? TipoHumor { get; set; }
    public bool? PermiteVisualizacao { get; set; }
}