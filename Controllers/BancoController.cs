using ApiCep.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiCep.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _bancoService;

        public BancoController(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }

        [HttpGet("buscar/{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBancoAsync([FromRoute] int codigo) 
        {
            var response = await _bancoService.GetBancoAsync(codigo);

            if (response.CodigoHtpp == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            else
            {
                return StatusCode((int)response.CodigoHtpp, response.ErroResponse);
            }
        }


        [HttpGet("buscar/todos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLisBancoAsync()
        {
            var response = await _bancoService.GetBancoListAsync();

            if (response.CodigoHtpp == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            else
            {
                return StatusCode((int)response.CodigoHtpp, response.ErroResponse);
            }
        }
    }

}
