using Natalia.Autorizacao.Domain.Entities;

namespace Natalia.Autorizacao.Domain.Common.Models
{
    public class Usuario : Tabela
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public DateTime DataAtivacao { get; set; }

        public bool ValidarCPF()
        {
            if (string.IsNullOrWhiteSpace(CPF))
                return false;

            CPF = new string(CPF.Where(char.IsDigit).ToArray());

            if (CPF.Length != 11)
                return false;

            if (CPF.Distinct().Count() == 1)
                return false;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = CPF.Substring(0, 9);
            int soma = tempCpf.Select((t, i) => (t - '0') * multiplicador1[i]).Sum();
            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            tempCpf += digito1;
            soma = tempCpf.Select((t, i) => (t - '0') * multiplicador2[i]).Sum();
            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return CPF.EndsWith($"{digito1}{digito2}");
        }
    }
}
