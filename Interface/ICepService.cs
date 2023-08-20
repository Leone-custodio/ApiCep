using ApiCep.Dto;
using ApiCep.Model;

namespace ApiCep.Interface
{
    public interface ICepService
    {
        Task<GenericResponse<CepResponse>> GetEnderecoAsync(string cep);
    }
}
