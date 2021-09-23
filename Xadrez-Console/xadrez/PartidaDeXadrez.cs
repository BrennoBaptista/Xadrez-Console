using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    public class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno {get; private set;}
        public Cor JogadorAtual { get; private set; }
        public bool PartidaTerminada { get; set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            PartidaTerminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            MontarTabuleiro();
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void MontarTabuleiro()
        {
            ColocarNovaPeca('a', 1, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('h', 1, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('b', 1, new Bispo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('g', 1, new Bispo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('c', 1, new Cavalo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('f', 1, new Cavalo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('d', 1, new Rei(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('e', 1, new Rainha(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('a', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('b', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('c', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('d', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('e', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('f', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('g', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('h', 2, new Peao(Cor.Branca, Tabuleiro));

            ColocarNovaPeca('a', 8, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('h', 8, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('b', 8, new Bispo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('g', 8, new Bispo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('c', 8, new Cavalo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('f', 8, new Cavalo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('d', 8, new Rei(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('e', 8, new Rainha(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('a', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('b', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('c', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('d', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('e', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('f', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('g', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('h', 7, new Peao(Cor.Preta, Tabuleiro));
        }
        
        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
            if(pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
        }

        public void ValidarPosicaoDeOrigem(Posicao posicao)
        {
            if (Tabuleiro.RetornarPeca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça ma posição de origem escolhida!");
            }

            if(JogadorAtual != Tabuleiro.RetornarPeca(posicao).Cor)
            {
                throw new TabuleiroException("A peça escolhida não é sua");
            }
            if (!Tabuleiro.RetornarPeca(posicao).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.RetornarPeca(origem).ValidarMovimento(destino))
            {
                throw new TabuleiroException("Posicao de destino inválida!");
            }
        }

        public void RealizarJogada(Posicao origem, Posicao destino)
        {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }

        private void MudarJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }
    }
}
