using System;
using System.Configuration;
using System.IO;

namespace RaceAppGrupoCriar.Business
{
    public static class FileValidade
    {
        // Classe para validação se existe arquivo para ser importado
        public static void ExisteArquivo()
        {
            // Declarando caminho do arquivo
            string curFile = ConfigurationManager.AppSettings["InputFileLocation"];

            // Verificando se o arquivo existe
            if (!File.Exists(curFile))
            {
                // Printando na tela o erro para o usuario
                Console.WriteLine("Arquivo não encontrado");
                Console.ReadLine();

                // Fechando a aplicação
                Environment.Exit(0);
            }
        }
    }
}
