using AutoMapper;
using Humor.Api.MappingsDto.ViewModels;
using HumorDomain = Humor.Api.Models.Humor;

namespace Humor.Api.MappingsDto;

public class DomainToVIewModelMappingProfile : Profile
{
    public DomainToVIewModelMappingProfile()
    {
        CreateMap<HumorDomain, HumorViewModelGrid>()
            .ForMember(vm => vm.DescricaoHumor, opt => opt.MapFrom(src => src.Descricao))
            .ForMember(vm => vm.TituloHumor, opt => opt.MapFrom(src => src.Titulo))
            .ForMember(vm => vm.TipoDoHumor, opt => opt.MapFrom(src => src.TipoHumor));
        CreateMap<HumorDomain, CreateHumorViewModel>();
        CreateMap<HumorDomain, UpdateHumorViewModel>();
    }
}