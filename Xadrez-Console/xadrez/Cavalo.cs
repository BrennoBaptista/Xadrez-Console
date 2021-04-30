using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    public class Cavalo : Peca
    {
        public Cavalo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "H";
        }
    }
}