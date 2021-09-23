using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    public class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
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
            while (Tabuleiro.ValidarPosicao(posicao) && ValidarMovimento(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.RetornarPeca(posicao) != null && Tabuleiro.RetornarPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Linha--; //= posicao.Linha - 1;
            }

            return matriz;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}