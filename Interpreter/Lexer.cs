using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Lexer
    {
        private static readonly List<Terminal> _terminals = new List<Terminal>
        {
          new Terminal(TokenType.VAR, "^[a-zA-Z_]{1}\\w*$"),
            new Terminal(TokenType.NUMBER, "0|[1-9][0-9]*"),
            new Terminal(TokenType.ASSIGN_OP, "="),
            new Terminal(TokenType.WHILE_KW, "while", 1),
            new Terminal(TokenType.IF_KW, "if", 1),
            new Terminal(TokenType.ELSE_KW, "else", 1),
            new Terminal(TokenType.DO, "do", 1),
            new Terminal(TokenType.PRINT, "print"),
            new Terminal(TokenType.LEFT_PAREN, "\\("),
            new Terminal(TokenType.RIGHT_PAREN, "\\)"),
            new Terminal(TokenType.WHITESPACE, "\\s+")
        };

        private static Boolean terminalMatches(StringBuilder buffer)
        {
            return lookupTerminals(buffer).Count != 0;
        }
        private static Terminal getTerminalPriority(List<Terminal> terminals)
        {
            Terminal terminalPriority = terminals.ElementAt(0);

            foreach (Terminal terminal in terminals)
            {
                if (terminal.getPriority() > terminalPriority.getPriority()) { terminalPriority = terminal; }
            }
            return terminalPriority;
        }
        private static List<Terminal> lookupTerminals(StringBuilder buffer)
        {
            List<Terminal> terminals = new List<Terminal>();

            foreach (Terminal terminal in _terminals)
            {
                if (terminal.termMatches(buffer.ToString())) { terminals.Add(terminal); }
            }
            return terminals;
        }

        private static Lexeme extractNextLexeme(StringBuilder input)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(input[0]);
            if (terminalMatches(builder))
            {
                while (terminalMatches(builder) && builder.Length != input.Length)
                {
                    builder.Append(input[builder.Length]);
                }
                builder.Remove(builder.Length-1,1);
                List<Terminal> terminals = lookupTerminals(builder);
                return new Lexeme(getTerminalPriority(terminals), builder.ToString());
            }
            else { throw new SystemException("Unexpected symbol" + builder); }
        }

        public static List<Lexeme> getTokenList(String test)
        {
            StringBuilder input = new StringBuilder();
            List<Lexeme> lexemes = new List<Lexeme>();
            input.Append(test);
            input.Append('$');
            while (input[0] != '$')
            {
                Lexeme lexeme = extractNextLexeme(input);
                lexemes.Add(lexeme);
                if (lexeme.getTerminal().getTokenType().Equals(TokenType.WHITESPACE)) { lexemes.Add(lexeme); }
                input.Remove(0, lexeme.getValue().Length);
            
            }
  
            return lexemes;

        }

        private static StringBuilder lookupInput(String[] args)
        {
            if (args.Length == 0) { throw new ArgumentException("input string not found"); }
            StringBuilder buff = new StringBuilder();
            foreach (String arg in args) { buff.Append(arg).Append(" "); }
            return buff;
        }

        /*public static void print(List<Lexeme> lexemes)
        {
            foreach (Lexeme lexeme in lexemes)
            {
                //работает только я не могу посмотреть из-за статического метода
                Console.WriteLine();
                Console.Write(String.Format(" {0}{1} ", lexeme.getTerminal().getTokenType(), lexeme.getValue()));
            
            }
        }*/
    }
}