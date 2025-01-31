using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Natalia.Autorizacao.Domain.Requests.Usuarios
{
    public class CadastrarUsuarioRequest : IRequest<bool>
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 6)]
        public string Senha { get; set; }

        [Required]
        public string CPF { get; set; }
    }
}
