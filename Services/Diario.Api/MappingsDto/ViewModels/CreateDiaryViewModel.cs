using System.ComponentModel.DataAnnotations;

namespace Diario.Api.MappingsDto.ViewModels;

public class CreateDiaryViewModel
{
    [Required(ErrorMessage = "Diario precisa ser informado")]
    [MaxLength(800)]
    public string Descricao { get; set; }
}