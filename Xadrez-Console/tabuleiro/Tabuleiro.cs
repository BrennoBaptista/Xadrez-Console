using System.Resources;

namespace Xadrez_Console.tabuleiro
{
    public class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro()
        {

        }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca RetornarPeca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca RetornarPeca(Posicao posicao)
        {
            return Pecas[posicao.Linha, posicao.Coluna];
        }

        public bool VerificarExistenciaPeca(Posicao posicao)
        {
            VerificarPosicao(posicao);
            return RetornarPeca(posicao) != null;
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if (VerificarExistenciaPeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        public bool ValidarPosicao(Posicao posicao)
        {
            if(posicao.Linha<0 || posicao.Linha >= Linhas || posicao.Coluna<0 || posicao.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void VerificarPosicao(Posicao posicao)
        {
            if (!ValidarPosicao(posicao))
            {
                throw new TabuleiroException("Posicao inválida!");
            }
        }
    }
}
