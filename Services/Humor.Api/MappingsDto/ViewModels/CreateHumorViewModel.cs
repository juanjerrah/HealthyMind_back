using System.ComponentModel.DataAnnotations;
using Humor.Api.Models.Enums;

namespace Humor.Api.MappingsDto.ViewModels;

public class CreateHumorViewModel
{
    [Required(ErrorMessage = "Titulo é obrigatório")]
    [MaxLength(50)]
    public string Titulo { get; set; }
    
    [Required(ErrorMessage = "Descrição é obrigatória")]
    [MaxLength(500)]
    public string Descricao { get; set; }
    
    [Required(ErrorMessage = "Tipo do humor é obrigatório")]
    public ETipoHumor TipoHumor { get; set; }
    public bool PermiteVisualizacao { get; set; } = true;
}