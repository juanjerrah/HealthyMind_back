namespace Diario.Api.MappingsDto.ViewModels;

public class DiarioViewModel
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public DateTimeOffset DataInclusao { get; set; }
    public DateTimeOffset DataALteracao { get; set; }
}