using System;
using System.Security.Cryptography;
using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    public class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        private int _turno;
        private Cor _jogadorAtual;
        public bool PartidaTerminada { get; set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            _turno = 1;
            _jogadorAtual = Cor.Branca;
            PartidaTerminada = false;
            ColocarPecas();
        }

        private void ColocarPecas()
        {
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('a',1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('h', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Cor.Branca, Tabuleiro), new PosicaoXadrez('b', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Cor.Branca, Tabuleiro), new PosicaoXadrez('g', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Branca, Tabuleiro), new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Branca, Tabuleiro), new PosicaoXadrez('f', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.Branca, Tabuleiro), new PosicaoXadrez('d', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Rainha(Cor.Branca, Tabuleiro), new PosicaoXadrez('e', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('a', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('b', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('c', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('d', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('e', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('f', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('g', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('h', 2).ToPosicao());

            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('a', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('h', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Cor.Preta, Tabuleiro), new PosicaoXadrez('b', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Cor.Preta, Tabuleiro), new PosicaoXadrez('g', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Preta, Tabuleiro), new PosicaoXadrez('c', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Preta, Tabuleiro), new PosicaoXadrez('f', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.Preta, Tabuleiro), new PosicaoXadrez('d', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Rainha(Cor.Preta, Tabuleiro), new PosicaoXadrez('e', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('a', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('b', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('c', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('d', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('e', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('f', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('g', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('h', 7).ToPosicao());
        }
        
        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
        }
    }
}
