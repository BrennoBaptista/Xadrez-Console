using System;

namespace tabuleiro
{
    public class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int l = 0; l < tab.Linhas; l++)
            {
                for (int c = 0; c < tab.Colunas; c++)
                {
                    if(tab.RetornaPeca(l, c) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.RetornaPeca(l, c) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
