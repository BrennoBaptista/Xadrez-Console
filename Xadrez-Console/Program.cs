﻿using System;
using Xadrez_Console.tabuleiro;
using Xadrez_Console.xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.PartidaTerminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicao().ToPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicao().ToPosicao();

                    partida.ExecutarMovimento(origem, destino);
                }
                
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            } 
        }
    }
}
