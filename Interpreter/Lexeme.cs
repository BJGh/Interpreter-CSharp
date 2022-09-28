using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Lexeme
    {
        private readonly Terminal terminal;
        private readonly String value;

        public Lexeme(Terminal terminal, String value)
        {
            this.terminal = terminal;
            this.value = value;
        }
        public Terminal getTerminal()
        {
            return terminal;
        }
        public String getValue()
        {
            return value;
        }
    }

}
