using AutoMapper;
using Core.Api.Utility;
using Humor.Api.MappingsDto.ViewModels;
using Humor.Api.Service;
using Microsoft.AspNetCore.Mvc;
using HumorDomain = Humor.Api.Models.Humor;

namespace Humor.Api.Controllers;

[Route("api/Humor")]
public class HumorController : Controller
{
    private readonly IHumorRepository _repository;
    private readonly IMapper _mapper;

    public HumorController(IHumorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<HumorViewModelGrid> GetHumores([FromQuery]HumorViewModelFilter filter,
        int? start = null, int? length = null)
    {
        var predicate = ExpressionExtension.Begin<HumorDomain>(true);
        
        if (filter.Id is not null)
            predicate = predicate.And(h => h.Id.Equals(filter.Id));
        if (!string.IsNullOrWhiteSpace(filter.Titulo))
            predicate = predicate.And(h => h.Titulo.ToUpper().Contains(filter.Titulo.ToUpper()));
        if (!string.IsNullOrWhiteSpace(filter.Descricao))
            predicate = predicate.And(h => h.Descricao.ToUpper().Contains(filter.Descricao.ToUpper()));
        if (filter.PermiteVisualizacao is not null)
            predicate = predicate.And(h => h.PermiteVisualizacao.Equals(filter.PermiteVisualizacao));
        if (filter.TipoHumor is not null)
            predicate = predicate.And(h => h.TipoHumor.Equals(filter.TipoHumor));
        if (filter.DataInicio is not null)
            predicate = predicate.And(h => h.DataInclusao >= filter.DataInicio);
        if (filter.DataFim is not null)
            predicate = predicate.And(h => h.DataInclusao <= filter.DataFim);
        
        var humores = _repository.ObterHumores(predicate, start, length);

        return _mapper.Map<IEnumerable<HumorViewModelGrid>>(humores);
    }

    [HttpPost]
    public ActionResult<Guid> PostHumor(CreateHumorViewModel viewModel)
    {
        var humor = new HumorDomain(Guid.NewGuid(), viewModel.Titulo, viewModel.Descricao, 
            viewModel.PermiteVisualizacao, viewModel.TipoHumor);
        humor.SetDataInclusao(DateTimeOffset.UtcNow);
        humor.SetDataAlteracao(DateTimeOffset.UtcNow);

        _repository.InserirHumor(humor);
        _repository.SaveChanges();
        return humor.Id;
    }
    
    [HttpPut]
    public IActionResult UpdateHumor(UpdateHumorViewModel humorViewModel)
    {
        var currentHumor = _repository.ObterHumorPorId(humorViewModel.Id);
        if (currentHumor is null)
            return NotFound("Diario não encontrado!");

        if(!string.IsNullOrWhiteSpace(humorViewModel.Titulo))
            currentHumor.SetTitulo(humorViewModel.Titulo);
        if(!string.IsNullOrWhiteSpace(humorViewModel.Descricao))
            currentHumor.SetDescricao(humorViewModel.Descricao);
        if(humorViewModel.PermiteVisualizacao is not null)
            currentHumor.SetPermiteVisualizacao(humorViewModel.PermiteVisualizacao.Value);
        if(humorViewModel.TipoHumor is not null)
            currentHumor.SetTipoHumor(humorViewModel.TipoHumor.Value);
        
        currentHumor.SetDataAlteracao(DateTimeOffset.UtcNow);
        
        _repository.AtualizarHumor(currentHumor);
        _repository.SaveChanges();
        return Ok();
    }
    
    [HttpDelete]
    public void ApagarDiario(Guid id)
    {
        var diario = _repository.ObterHumorPorId(id);
        if (diario == null) return;
        _repository.DeletarHumor(diario);
        _repository.SaveChanges();
    }
}