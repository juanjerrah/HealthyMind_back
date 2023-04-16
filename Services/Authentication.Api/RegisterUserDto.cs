namespace Authentication.Api;

public class RegisterUserDto
{
    public string Email { get; set; }
    public string NomeUsuario { get; set; }
    public string Password { get; set; }
    public Guid PerfilId { get; set; }
}