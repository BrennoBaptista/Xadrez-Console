using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    public class Bispo : Peca
    {
        public Bispo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "B";
        }
    }
}