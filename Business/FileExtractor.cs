using RaceAppGrupoCriar.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace RaceAppGrupoCriar.Business
{
    public class FileExtractor
    {
        // Extrai as informações do arquivo de entrada e retornar uma Lista
        public static List<Piloto> ExtractRacingLog()
        {
            // Recuperando Caminho do Arquivo de Entrada
            string path = ConfigurationManager.AppSettings["InputFileLocation"];

            // Leitura do Arquivo de Entrada
            List<string> linhas = File.ReadAllLines(path).ToList();

            // Criação de Nova Lista de Pilotos
            List<Piloto> piloto = new List<Piloto>();

            foreach (string linha in linhas)
            {
                // Split das colunas da linha por " " (espaços)
                string[] entradas = linha.Split(new Char[] { ' ' });

                Piloto PilotoNovo = new Piloto();

                // Formatação da Coluna HORA
                string formatoHoraLog = @"hh\:mm\:ss\.fff";

                // Formatação da Coluna Tempo de Volta
                string formatoTempoVolta = @"m\:ss\.fff";

                try
                {
                    // Set da Hora - Convertida para TimeSpan
                    PilotoNovo.hora = TimeSpan.ParseExact(entradas[0].ToString(), formatoHoraLog, null);

                    // Set do Código do Piloto
                    PilotoNovo.codigoPiloto = Convert.ToInt32(entradas[1]);

                    // Set do Nome do Piloto
                    PilotoNovo.nomePiloto = entradas[3];

                    // Set do Numero de Volta
                    PilotoNovo.numeroVolta = Convert.ToInt32(entradas[4]);

                    // Set da Velocidade Média Volta
                    PilotoNovo.velocidadeMediaVolta = Convert.ToDouble(entradas[6]);

                    // Set Tempo Volta
                    PilotoNovo.tempoVolta = TimeSpan.ParseExact(entradas[5].ToString(), formatoTempoVolta, null);

                    // Adicionar na Lista
                    piloto.Add(PilotoNovo);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return piloto;
        }
    }
}
