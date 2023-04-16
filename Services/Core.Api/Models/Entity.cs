namespace Core.Api.Models;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTimeOffset DataInclusao { get; set; }
    public DateTimeOffset DataAlteracao { get; set; }
}