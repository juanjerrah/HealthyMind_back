namespace Diario.Api.Models;

public class Diario : Entity
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }

    public Diario()
    {
        
    }

    public Diario(string descricao)
    {
        Descricao = descricao;
    }

    public Diario(Guid id, string descricao) : this(descricao)
    {
        Id = id;
    }

    public void SetDescricao(string descricao) => Descricao = descricao;
    public void SetDataInclusao(DateTimeOffset dataInclusao) => DataInclusao = dataInclusao;
    public void SetDataAlteracao(DateTimeOffset dataAlteracao) => DataAlteracao = dataAlteracao;

}