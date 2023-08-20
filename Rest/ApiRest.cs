using ApiCep.Dto;
using ApiCep.Interface;
using ApiCep.Model;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace ApiCep.Rest
{
    public class ApiRest : IApiService
    {
        public async Task<GenericResponse<BancoModel>> GetBancoAsync(int codigo)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/banks/v1/{codigo}");
            var response = new GenericResponse<BancoModel>();
            using(var client = new HttpClient())
            {
                var responseApi = await client.SendAsync(request);
                var contentResp = await responseApi.Content.ReadAsStringAsync();
                var objResp = JsonSerializer.Deserialize<BancoModel>(contentResp);

                if (responseApi.IsSuccessStatusCode)
                {
                    response.CodigoHtpp = responseApi.StatusCode;
                    response.DadosRetorno = objResp;
                }
                else
                {
                    response.CodigoHtpp = responseApi.StatusCode;
                    response.ErroResponse = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;
        }

        public async Task<GenericResponse<List<BancoModel>>> GetBancoListAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://brasilapi.com.br/api/banks/v1/");
            var response = new GenericResponse<List<BancoModel>>();
            using (var client = new HttpClient())
            {
                var responseApi = await client.SendAsync(request);
                var contentResp = await responseApi.Content.ReadAsStringAsync();
                var objResp = JsonSerializer.Deserialize<List<BancoModel>>(contentResp);

                if (responseApi.IsSuccessStatusCode)
                {
                    response.CodigoHtpp = responseApi.StatusCode;
                    response.DadosRetorno = objResp;
                }
                else
                {
                    response.CodigoHtpp = responseApi.StatusCode;
                    response.ErroResponse = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;

        }

        public async Task<GenericResponse<CepModel>> GetEnderecoAsync(string cep)
        {
            var request = new HttpRequestMessage(HttpMethod.Get , $"https://brasilapi.com.br/api/cep/v1/{cep}");
            var response = new GenericResponse<CepModel>();

            using(var client = new HttpClient())
            {
                var responseApi = await client.SendAsync(request);
                var contentResp = await responseApi.Content.ReadAsStringAsync();
                var objResp = JsonSerializer.Deserialize<CepModel>(contentResp);

                if(responseApi.IsSuccessStatusCode)
                {
                    response.CodigoHtpp = responseApi.StatusCode;
                    response.DadosRetorno = objResp;
                }
                else
                {
                    response.CodigoHtpp = responseApi.StatusCode;
                    response.ErroResponse = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;
        }
        
    }
}
