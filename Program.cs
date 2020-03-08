using RaceAppGrupoCriar.Model;
using RaceAppGrupoCriar.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceAppGrupoCriar
{
    class Program
    {
        static void Main(string[] args)
        {
            // Validação se o arquivo existe
            FileValidade.ExisteArquivo();

            // Extração dos Registros do Arquivo de Entrada
            Race.LogRacing();
            Console.ReadLine();
        }
    }
}
