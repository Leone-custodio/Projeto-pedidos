using Microsoft.AspNetCore.Mvc;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosAplication.Controllers
{
    [Route("api/v1/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly ICepService _service;

        public CepController(ICepService service)
        {
            _service = service;
        }

        [HttpGet("buscar/{cep}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarEndereco([FromRoute] string cep)
        {
            var response = await _service.GetEnderecoAsync(cep);

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
