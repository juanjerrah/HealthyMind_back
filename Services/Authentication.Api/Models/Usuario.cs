using Authentication.Api.Models.Enums;

namespace Authentication.Api.Models;

public class Usuario : Entity
{
    public string NomeUsuario { get; private set; }
    public string Email { get; private set; }
    public byte[] PasswordHash { get; private set; }
    public byte[] PasswordSalt { get; private set; }
    public string? CodigoRecuperacao { get; private set; }
    public Guid TipoPerfilId { get; private set; }
    public bool Status { get; private set; }

    public Usuario()
    {
    }

    public Usuario(string nomeUsuario, string email, byte[] passwordHash, byte[] passwordSalt, bool status,  
        Guid tipoPerfilId, string? codigoRecuperacao = null)
    {
        NomeUsuario = nomeUsuario;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        Status = status;
        CodigoRecuperacao = codigoRecuperacao;
        TipoPerfilId = tipoPerfilId;
    }
    public Usuario(Guid id, string nomeUsuario, string email, byte[] passwordHash, byte[] passwordSalt, bool status,  
        Guid tipoPerfilId, string? codigoRecuperacao = null) 
        : this(nomeUsuario, email, passwordHash, passwordSalt, status, tipoPerfilId, codigoRecuperacao)
    {
        Id = id;
    }

    public void SetUserName(string userName) => NomeUsuario = userName;
    public void SetEmail(string email) => Email = email;
    public void SetPasswordHash(byte[] passwordHash) => PasswordHash = passwordHash;
    public void SetPasswordSalt(byte[] passwordSalt) => PasswordSalt = passwordSalt;
    public void SetStatus(bool status) => Status = status;
    public void SetCodigoRecuperacao(string codigoRecuperacao) => CodigoRecuperacao = codigoRecuperacao;
    public void SetTipoPerfilUsuario(Guid tipoPerfilId) => TipoPerfilId = tipoPerfilId;

}
