using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Authentication.Api.Data;
using Authentication.Api.Models;
using Authentication.Api.Service.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthContext _context;
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;

    public AuthController(IConfiguration configuration, IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    [HttpGet, Authorize]
    public ActionResult<string> GetMe()
    {
        var userName = _userService.GetMyName();
        return Ok(userName);
    }

    [HttpPost("register")]
    public async Task<ActionResult<Usuario>> Register(RegisterUserDto request)
    {
        var usuario = _context.Usuarios
            .FirstOrDefaultAsync(x => x.NomeUsuario == request.NomeUsuario).Result;
        if (usuario != null)
            return BadRequest("Usuário já existe");
        
        CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

        var user = new Usuario(Guid.NewGuid(), request.NomeUsuario, request.Email, passwordHash, 
            passwordSalt, true, request.PerfilId)
        {
            DataInclusao = DateTimeOffset.Now,
            DataAlteracao = DateTimeOffset.Now
        };

        await _context.Usuarios.AddAsync(user);
        await _context.SaveChangesAsync();

        var token = CreateToken(user);

        return Ok(token);
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(UserDto request)
    {
        var user = _context.Usuarios.FirstOrDefaultAsync(x => x.NomeUsuario == request.Username).Result;

        if (user is null)
        {
            return BadRequest("Usuário ou senha incorreto");
        }

        if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
        {
            return BadRequest("Usuário ou senha incorreto");
        }

        var token = CreateToken(user);

        return Ok(token);
    }

    /*[HttpPost("refresh-token")]
    public async Task<ActionResult<string>> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];

        if (!_user.RefreshToken.Equals(refreshToken))
        {
            return Unauthorized("Invalid Refresh Token.");
        }

        if (_user.TokenExpires < DateTime.Now)
        {
            return Unauthorized("Token expired.");
        }

        string token = CreateToken(_user);
        var newRefreshToken = GenerateRefreshToken();
        SetRefreshToken(newRefreshToken);

        return Ok(token);
    }*/

    /*private RefreshToken GenerateRefreshToken()
    {
        var refreshToken = new RefreshToken
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expires = DateTime.Now.AddDays(7),
            Created = DateTime.Now
        };

        return refreshToken;
    }*/

    /*
    private void SetRefreshToken(RefreshToken newRefreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = newRefreshToken.Expires
        };
        Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

        _user.RefreshToken = newRefreshToken.Token;
        _user.TokenCreated = newRefreshToken.Created;
        _user.TokenExpires = newRefreshToken.Expires;
    }*/

    private string CreateToken(Usuario user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.NomeUsuario),
            new(ClaimTypes.Role, user.TipoPerfilId.ToString())
        };

        var value = _configuration.GetSection("AppSettings:Token").Value;
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}