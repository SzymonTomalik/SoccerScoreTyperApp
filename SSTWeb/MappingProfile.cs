using AutoMapper;
using SSTDataAccessLibrary.Models;

namespace SSTWeb
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.UserRegistrationModel, Typer>()
                            .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Login));
            CreateMap<Models.ExternalLoginModel, Typer>()
                            .ForMember(u => u.Login, opt => opt.MapFrom(x => x.UserName));
        }
    }
}