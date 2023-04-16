using System.ComponentModel.DataAnnotations;

namespace Diario.Api.MappingsDto.ViewModels;

public class UpdateDiarioViewModel
{
    [Required(ErrorMessage = "Id é obrigatorio")]
    public Guid Id { get; set; }
    public string? Descricao { get; set; }
}