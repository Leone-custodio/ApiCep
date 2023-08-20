using ApiCep.Dto;
using ApiCep.Interface;
using AutoMapper;

namespace ApiCep.Service
{
    public class CepService : ICepService
    {
        private readonly IMapper _mapper;
        private readonly IApiService _apiService;

        public CepService(IMapper mapper, IApiService apiService)
        {
            _mapper = mapper;
            _apiService = apiService;
        }

        public async Task<GenericResponse<CepResponse>> GetEnderecoAsync(string cep)
        {
            var endereco = await _apiService.GetEnderecoAsync(cep);
            return _mapper.Map<GenericResponse<CepResponse>>(endereco);
        }
    }
}
