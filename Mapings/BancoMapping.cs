using ApiCep.Dto;
using ApiCep.Model;
using AutoMapper;

namespace ApiCep.Mapings
{
    public class BancoMapping : Profile
    {
        public BancoMapping()
        {
            CreateMap(typeof(GenericResponse<>), typeof(GenericResponse<>));
            CreateMap<BancoResponse, BancoModel>();
            CreateMap<BancoModel, BancoResponse>();
        }
    }
}
