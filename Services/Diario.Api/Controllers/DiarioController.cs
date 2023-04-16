using AutoMapper;
using Diario.Api.MappingsDto.ViewModels;
using Diario.Api.Service;
using Microsoft.AspNetCore.Mvc;
using DiarioDomain = Diario.Api.Models.Diario;

namespace Diario.Api.Controllers;

[Route("api/Diario")]
public class DiarioController : Controller
{
    private readonly IDiarioRepository _repository;

    private readonly IMapper _mapper;
    // GET
    public DiarioController(IDiarioRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<DiarioViewModelGrid> ObterDiarios()
    {
        var diarios = _repository.ObterDiarios();
        return _mapper.Map<IEnumerable<DiarioViewModelGrid>>(diarios);
    }

    [HttpGet]
    [Route("PorId")]
    public ActionResult<DiarioViewModelGrid?> ObterDiarioPorId([FromQuery] Guid? id)
    {
        if (id == null)
        {
            return BadRequest("Id é necessário");
        }
        var diario = _repository.ObterDiarioPorId(id);
        return _mapper.Map<DiarioViewModelGrid>(diario);
    }

    [HttpPost]
    public Guid? InserirDiario(CreateDiaryViewModel diario)
    {
        var diary = new DiarioDomain(Guid.NewGuid(), diario.Descricao);
        diary.SetDataInclusao(DateTimeOffset.UtcNow);
        diary.SetDataAlteracao(DateTimeOffset.UtcNow);

        _repository.InserirDiario(diary);
        _repository.SaveChanges();
        return diary.Id;
    }

    [HttpPut]
    public IActionResult UpdateDiario(UpdateDiarioViewModel diarioViewModel)
    {
        var currentDiario = _repository.ObterDiarioPorId(diarioViewModel.Id);
        if (currentDiario is null)
            return NotFound("Diario não encontrado!");

        if(!string.IsNullOrWhiteSpace(diarioViewModel.Descricao))
            currentDiario.SetDescricao(diarioViewModel.Descricao);
        currentDiario.SetDataAlteracao(DateTimeOffset.UtcNow);
        
        _repository.AtualizarDiario(currentDiario);
        _repository.SaveChanges();
        return Ok();
    }
    
    [HttpDelete]
    public void ApagarDiario(Guid id)
    {
        var diario = _repository.ObterDiarioPorId(id);
        if (diario == null) return;
        _repository.DeletarDiario(diario);
        _repository.SaveChanges();
    }
}