using ApiCep.Dto;
using ApiCep.Model;
using AutoMapper;

namespace ApiCep.Mapings
{
    public class EnderecoMaping : Profile
    {
        public EnderecoMaping()
        {
            CreateMap(typeof(GenericResponse<>), typeof(GenericResponse<>));
            CreateMap<CepResponse, CepModel>();
            CreateMap<CepModel, CepResponse >();
        }
    }
}
