using MediatR;
using Microsoft.Extensions.Logging;
using Natalia.Autorizacao.Domain.Requests.Usuarios;
using Natalia.Autorizacao.Domain.Retorno;
using Natalia.Autorizacao.Infrastructure.Repositories;
using Natalia.Autorizacao.Infrastructure.Services;

namespace Natalia.Autorizacao.Infrastructure.Handlers.Usuarios
{
    public class CadastrarUsuarioHandler : IRequestHandler<CadastrarUsuarioRequest, bool>
    {
        private readonly ILogger<CadastrarUsuarioHandler> _logger;
        private readonly IUsuarioRepositorio _repositorio;

        public CadastrarUsuarioHandler(ILogger<CadastrarUsuarioHandler> logger, IUsuarioRepositorio repositorio)
        {
            _logger = logger;
            _repositorio = repositorio;
        }

        public async Task<bool> Handle(CadastrarUsuarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var dadosValidados = ValidarRequest(request);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "MensagensErro.", request);
                return new Retorno<bool>(MensagensErro.);
            }
        }

        private bool ValidarRequest(CadastrarUsuarioRequest request)
        {
            var usuarioExiste = _repositorio.VerificarUsuario(request.CPF, request.Nome);
            if (usuarioExiste.Result)
                throw new Exception("");

            var cpfSomenteNumeros = request.CPF.ObterApenasNumeros();
            var senhaCriptografada = CriptografiaService.EncriptarDados(request.Senha);

            return true;
        }
    }
}
