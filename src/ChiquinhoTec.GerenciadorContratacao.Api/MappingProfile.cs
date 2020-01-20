using AutoMapper;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Results;

namespace ChiquinhoTec.GerenciadorContratacao.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, AddressResult>();

            CreateMap<Interview, InterviewResult>();

            CreateMap<Person, PersonResult>()
                .ForMember(dest => dest.Email, o => o.MapFrom(src => src.Email.Value))
                .ForMember(dest => dest.Cpf, o => o.MapFrom(src => src.Cpf.Value));
        }
    }
}