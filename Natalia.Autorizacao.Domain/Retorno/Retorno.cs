namespace Natalia.Autorizacao.Domain.Retorno
{
    public class Retorno<T>
    {
        public Retorno(T dados)
        {
            Sucesso = true;
            Mensagens = new List<string>();
            Dados = dados;
        }

        public Retorno(string mensagemErro)
        {
            Sucesso = false;
            Mensagens = new List<string>();
            Dados = default;
            Mensagens.Add(mensagemErro);
        }

        public bool Sucesso { get; set; }
        public List<string> Mensagens { get; }
        public T Dados { get; set; }
    }
}
