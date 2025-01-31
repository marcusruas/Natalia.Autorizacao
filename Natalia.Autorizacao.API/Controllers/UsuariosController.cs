using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Natalia.Autorizacao.Domain.Requests.Usuarios;

namespace Natalia.Autorizacao.API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarUsuarioRequest usuario) =>
            Ok(await _mediator.Send(usuario));
    }
}
