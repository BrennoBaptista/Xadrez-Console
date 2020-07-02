using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    public class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "P";
        }
    }
}