using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class ASTLeaf:AstNode
    {
        List<Lexeme> childs = new List<Lexeme>();
        public  ASTLeaf(String text) : base(text) { }

        public void AddChild(Lexeme lexeme)
        {
            childs.Add(lexeme);
        }
    }
}
