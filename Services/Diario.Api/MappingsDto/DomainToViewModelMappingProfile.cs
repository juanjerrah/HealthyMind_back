using AutoMapper;
using Diario.Api.MappingsDto.ViewModels;

namespace Diario.Api.MappingsDto;

public class DomainToViewModelMappingProfile: Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Models.Diario, CreateDiaryViewModel>();
        CreateMap<Models.Diario, DiarioViewModelGrid>();
        CreateMap<Models.Diario, DiarioViewModel>();
    }
}