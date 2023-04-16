using Authentication.Api.Data;
using Authentication.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers;

[Route("api/Perfil")]
public class PerfilController : Controller
{
    private readonly AuthContext _context;

    public PerfilController(AuthContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> AddPerfil(Perfil perfil)
    {
        var perf = new Perfil(Guid.NewGuid(), perfil.Nome, perfil.TipoPerfil)
        {
            DataInclusao = DateTimeOffset.Now,
            DataAlteracao = DateTimeOffset.Now
        };

        await _context.Perfis.AddAsync(perf);
        await _context.SaveChangesAsync();
        
        return Ok(perf.Id);
    }
}