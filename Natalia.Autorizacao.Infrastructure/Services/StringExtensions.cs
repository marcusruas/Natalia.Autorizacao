namespace Natalia.Autorizacao.Infrastructure.Services
{
    public static class StringExtensions
    {
        public static string ObterApenasNumeros(this string obterApenasNumeros)
        {
            var documentoSomenteNumeros = "";
            for (int i = 0; i < obterApenasNumeros.Length; i++)
            {
                if (char.IsDigit(obterApenasNumeros[i]))
                    documentoSomenteNumeros += obterApenasNumeros[i];
            }
            return documentoSomenteNumeros;
        }

        public static string ObterQuery(string query)
        {
            try
            {
                string diretorio = Path.Combine(Directory.GetCurrentDirectory(), "bin");
                if (Directory.Exists(diretorio))
                {
                    string[] arquivos = Directory.GetFiles(diretorio, "*.sql");
                    if (arquivos.Length > 0)
                        return arquivos[0];
                }

                if (!string.IsNullOrEmpty(diretorio))
                {
                    string conteudoSql = File.ReadAllText(diretorio);
                    return conteudoSql;
                }
                else
                    throw new Exception("Arquivo SQL não encontrado.");
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
