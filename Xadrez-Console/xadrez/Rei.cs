using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    public class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tabuleiro) :base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
