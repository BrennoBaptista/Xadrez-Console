using System;
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
                    try
                    {


                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tabuleiro);

                        Console.WriteLine();
                        Console.Write("Turno: " + partida.Turno);
                        Console.WriteLine();
                        Console.Write("Aguardando jogada: " + partida.JogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicao().ToPosicao();
                        partida.ValidarPosicaoDeOrigem(origem);

                        bool[,] movimentosPossiveis = partida.Tabuleiro.RetornarPeca(origem).MovimentosPossiveis();
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tabuleiro, movimentosPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicao().ToPosicao();

                        partida.RealizarJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            } 
        }
    }
}
