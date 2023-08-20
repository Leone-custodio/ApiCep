using ApiCep.Dto;
using ApiCep.Interface;
using AutoMapper;

namespace ApiCep.Service
{
    public class BancoService : IBancoService
    {
        private readonly IMapper _mapper;
        private readonly IApiService _apiService;

        public BancoService(IMapper mapper, IApiService apiService)
        {
            _mapper = mapper;
            _apiService = apiService;
        }

        public async Task<GenericResponse<BancoResponse>> GetBancoAsync(int codigo)
        {
            var response = await _apiService.GetBancoAsync(codigo);
            return _mapper.Map<GenericResponse<BancoResponse>>(response);
        }

        public async Task<GenericResponse<List<BancoResponse>>> GetBancoListAsync()
        {
            var response = await _apiService.GetBancoListAsync();
            return _mapper.Map<GenericResponse<List<BancoResponse>>>(response);
        }
    }
}
