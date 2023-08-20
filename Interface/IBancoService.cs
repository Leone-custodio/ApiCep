using ApiCep.Dto;
using ApiCep.Model;

namespace ApiCep.Interface
{
    public interface IBancoService
    {
        Task<GenericResponse<List<BancoResponse>>> GetBancoListAsync();
        Task<GenericResponse<BancoResponse>> GetBancoAsync(int codigo);
    }
}
