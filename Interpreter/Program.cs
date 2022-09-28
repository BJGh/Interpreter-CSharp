using System;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = "var a var b var c = a + b";
            Lexer.getTokenList(s);
            
            Parser parser = new Parser();
          parser.setLexemes(  Lexer.getTokenList(s));
     
           parser.lang();

            
            Console.WriteLine("Hello World!");
        }
    }
}
