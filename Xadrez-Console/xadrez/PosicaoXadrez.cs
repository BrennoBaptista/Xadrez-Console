﻿using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    public class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        //public PosicaoXadrez(){}

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        public Posicao ToPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return Coluna.ToString().ToUpper()+Linha;
        }
    }
}
