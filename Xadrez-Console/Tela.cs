using System;
using Xadrez_Console.tabuleiro;

namespace Xadrez_Console
{
    public class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int l = 0; l < tab.Linhas; l++)
            {
                for (int c = 0; c < tab.Colunas; c++)
                {
                    if(tab.RetornarPeca(l, c) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.RetornarPeca(l, c) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
