using Core.Api.Models;
using Humor.Api.Models.Enums;

namespace Humor.Api.Models;

public class Humor : Entity
{
    //Attributes
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public bool PermiteVisualizacao { get; private set; }
    public ETipoHumor TipoHumor { get; private set; }

    //Constructors
    public Humor() { }
    public Humor(string titulo, string descricao, bool permiteVisualizacao, ETipoHumor tipoHumor)
    {
        Titulo = titulo;
        Descricao = descricao;
        PermiteVisualizacao = permiteVisualizacao;
        TipoHumor = tipoHumor;
    }

    public Humor(Guid id, string titulo, string descricao, bool permiteVisualizacao, ETipoHumor tipoHumor)
        : this(titulo, descricao, permiteVisualizacao, tipoHumor)
        => Id = id;
    
    //Setters
    public void SetTitulo(string titulo) => Titulo = titulo;
    public void SetDescricao(string descricao) => Descricao = descricao;
    public void SetPermiteVisualizacao(bool permiteVisualizacao) => PermiteVisualizacao = permiteVisualizacao;
    public void SetTipoHumor(ETipoHumor tipoHumor) => TipoHumor = tipoHumor;
    public void SetDataInclusao(DateTimeOffset dataInclusao) => DataInclusao = dataInclusao;
    public void SetDataAlteracao(DateTimeOffset dataAlteracao) => DataAlteracao = dataAlteracao;

}