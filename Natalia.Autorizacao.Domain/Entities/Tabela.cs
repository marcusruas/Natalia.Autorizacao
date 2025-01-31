namespace Natalia.Autorizacao.Domain.Entities
{
    public abstract class Tabela
    {
        public Tabela()
        {
            Id = Guid.NewGuid();
            DataCriacao = new DateTime();
            Ativo = true;
        }

        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
    }
}
