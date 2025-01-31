namespace Natalia.Autorizacao.Infrastructure.Repositories
{
    public interface IUsuarioRepositorio
    {
        Task<bool> VerificarUsuario(string cpf, string nome);
    }
}
