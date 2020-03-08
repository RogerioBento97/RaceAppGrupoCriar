using RaceAppGrupoCriar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RaceAppGrupoCriar.Business
{
    public static class Race
    {
        public static List<Piloto> Pilotos;

        public static void LogRacing()
        {

            Pilotos = FileExtractor.ExtractRacingLog();
            // Criação do objeto pil que recebe o List de pilotos
            List<Piloto> pil = Pilotos;

            // Construção da query utilizada
            var Resultado =
            from res in Pilotos
            group res by res.codigoPiloto into resGroup
            select new
            {
                // Recebendo o valor do codigo piloto
                CodigoPiloto = resGroup.Key,

                // Recebendo nome do piloto
                NomePiloto = resGroup.Max(x => x.nomePiloto),

                // Recebendo maior numero de volta
                NumeroVolta = resGroup.Max(x => x.numeroVolta),

                // Recebendo menor numero de volta
                MelhorVolta = resGroup.Min(x => x.tempoVolta),

                // Recebendo média de velocidade
                VelocidadeMedia = resGroup.Average(x => x.velocidadeMediaVolta),

                // Recebendo menor hora
                MenorHora = resGroup.Min(x => x.hora),

                // Recebendo maior hora
                MaiorHora = resGroup.Max(x => x.hora),

                // Recebendo tempo total das voltas
                TempoTotalVolta = new TimeSpan(resGroup.Sum(p => p.tempoVolta.Ticks)),

            };
            // Recebendo na variavel o campo MaiorHora que veio da query.
            TimeSpan tempoCorrida = (from q in Resultado orderby q.TempoTotalVolta descending select q.MaiorHora).FirstOrDefault();

            // Recebendo na variavel o campo MelhorVolta que veio da query.
            TimeSpan melhorVolta = (from q in Resultado orderby q.MelhorVolta select q.MelhorVolta).FirstOrDefault();

            // Recebendo na variavel o campo VelocidadeMedia que veio da query.
            Double velocidadeMedia = (from q in Resultado orderby q.VelocidadeMedia descending select q.VelocidadeMedia).FirstOrDefault();

            // Declarando contador de chegada
            int chegada = 0;

            // Legenda dos campos demonstrados
            Console.WriteLine($" CHEGADA | \tCODIGO   | \t  NOME \t\t |\tVOLTAS   | \t MELHOR VOLTA \t\t | \t TOTAL PROVA \n");

            // Loop para percorrer os valores da lista ordenados pelo tempo total da volta
            foreach (var item in Resultado.OrderBy(x => x.TempoTotalVolta))
            {
                // Atribuindo +1 para o contador de chegada
                chegada++;

                // Printando valores da lista
                Console.WriteLine($" {chegada} \t | \t {item.CodigoPiloto} \t | \t {item.NomePiloto} \t |" +
                                  $" \t {item.NumeroVolta} \t | \t{item.MelhorVolta} \t | \t {item.TempoTotalVolta}\n");
            }

            // Printando melhor volta da corrida
            Console.WriteLine($" MELHOR VOLTA: {melhorVolta} \n");
            // Printando velocidade média da corrida
            Console.WriteLine($" VELOCIDADE MÉDIA DA CORRIDA: {velocidadeMedia} ");
        }
    }

}
