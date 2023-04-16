using Authentication.Api.Models.Enums;

namespace Authentication.Api.Models;

public class Perfil : Entity
{
    public string Nome { get; private set; }
    public ETiposPerfis TipoPerfil { get; private set; }

    public Perfil(string nome, ETiposPerfis tipoPerfil)
    {
        Nome = nome;
        TipoPerfil = tipoPerfil;
    }
    
    public Perfil(Guid id, string nome, ETiposPerfis tipoPerfil) : this(nome, tipoPerfil)
    {
        Id = id;
    }

    public void SetPerfillNome(string nome) => Nome = nome;
    public void SetTipoPerfil(ETiposPerfis tipoPerfil) => TipoPerfil = tipoPerfil;
}