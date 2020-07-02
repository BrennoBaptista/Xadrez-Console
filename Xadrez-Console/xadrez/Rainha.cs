using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    public class Rainha : Peca
    {
        public Rainha(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}