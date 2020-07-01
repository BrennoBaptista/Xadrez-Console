using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Console.tabuleiro
{
    public class TabuleiroException : Exception
    {
        public TabuleiroException(string msg): base(msg)
        {
        }
    }
}
