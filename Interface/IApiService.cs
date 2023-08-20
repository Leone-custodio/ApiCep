using ApiCep.Dto;
using ApiCep.Model;

namespace ApiCep.Interface
{
    public interface IApiService
    {
        Task<GenericResponse<CepModel>> GetEnderecoAsync(string cep);
        Task<GenericResponse<List<BancoModel>>> GetBancoListAsync();
        Task<GenericResponse<BancoModel>> GetBancoAsync(int codigo);
    }
}
