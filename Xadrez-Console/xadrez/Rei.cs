using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    public class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tabuleiro) :base(cor, tabuleiro)
        {
        }

        private bool ValidarMovimento(Posicao posicao)
        {
            Peca peca = Tabuleiro.RetornarPeca(posicao);
            return peca == null || peca.Cor! != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);

            //acima
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if(Tabuleiro.ValidarPosicao(posicao)&& ValidarMovimento(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            //acima direita
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.ValidarPosicao(posicao) && ValidarMovimento(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            //direita
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.ValidarPosicao(posicao) && ValidarMovimento(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            //abaixo direita
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.ValidarPosicao(posicao) && ValidarMovimento(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            //abaixo
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.ValidarPosicao(posicao) && ValidarMovimento(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            //abaixo esquerda
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.ValidarPosicao(posicao) && ValidarMovimento(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            //esquerda
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.ValidarPosicao(posicao) && ValidarMovimento(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            //acima esquerda
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.ValidarPosicao(posicao) && ValidarMovimento(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }
            return matriz;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
