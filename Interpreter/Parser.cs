using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Parser
    {
        private List<Lexeme> lexemes;
        private int point = 0;
        public List<Lexeme> GetLexemes()
        {
            return lexemes;
        }
        public void setLexemes(List<Lexeme> lexemes)
        {
            this.lexemes = lexemes;
        }//?

        public AstNode lang()
        {

            AstNode node = new AstNode("lang");
            node.AddChild(expr());

            while (currentToken().getTerminal().getTokenType().Equals("VAR") | currentToken().getTerminal().getTokenType().Equals("IF_KW")) { node.AddChild(new ASTLeaf(Convert.ToString(expr()))); }
              
            return node;
   
        }

        private AstNode expr()
        {
            AstNode node = new AstNode("expr");
            if (currentToken().getTerminal().getTokenType().Equals("VAR"))
            {
                node.AddChild(assign_expr());
            }
            //   else if (currentToken().getTerminal().getTokenType().Equals("IF_KW"))
            // {node.AddChild(new ASTLeaf(Convert.ToString(if_expr())));}
            
            return node;

        }
        private AstNode assign_expr()
        {
            ASTLeaf node = new ASTLeaf("assign_expr");
            match(node, "VAR");
            match(node, "ASSIGN_OP");

            node.AddChild(value());
        
            return node;

        }

        private AstNode value()
        {
            ASTLeaf node = new ASTLeaf("value");
            if (currentToken().getTerminal().getTokenType().Equals("NUMBER"))
            {
                match(node, "NUMBER");

            } else if (currentToken().getTerminal().getTokenType().Equals("VAR"))
            {
                match(node, "VAR");
            }
            else { throw new SystemException("Invalid token" + currentToken()); }
            
            return node;
        }

   /*     private AstNode if_expr()
        {
            AstNode node = new AstNode("if_expr");
            node.AddChild(if_head());
            node.AddChild(body());
            if (lexemes.Count < point & currentToken().getTerminal().getTokenType().Equals("IF_KW")) { node.AddChild(else_head()); node.AddChild(body()); }
            return node;
        }
      /*  private AstNode if_head()
        {
            ASTLeaf node = new ASTLeaf("if_head");
            match(node, "IF_KW");
            node.AddChild(if_condition());
            return node;
        }
    /*    private AstNode if_condition()
        {
            ASTLeaf node = new ASTLeaf("if_condition");
            match(node, "LEFT_PAREN");
            node.AddChild(logical_expr());
            match(node, "RIGHT_PAREN");
            return node;
        } 

      /*  private AstNode logical_expr()
        {
            ASTLeaf node = new ASTLeaf("logical_expr");
            node.AddChild(value());
            while()
        }*/

          private AstNode body()
        {
            ASTLeaf node = new ASTLeaf("body");
            match(node, "LEFT_BRACE");
            while(currentToken().getTerminal().getTokenType().Equals("VAR"))
            {
                node.AddChild(expr());
            }
            match(node, "RIGHT_BRACE");
   ;
            return node;
        }



        private Lexeme currentToken()
        {
            if (point >= lexemes.Count)
            { point = lexemes.Count - 1; }
            return lexemes[point];
        }
 
        private void match(AstNode node, String terminal)
        {
            if (currentToken().getTerminal().getTokenType().Equals(terminal))
            { node.AddChild(new ASTLeaf(Convert.ToString(currentToken())));
                point++;
            }
            else
            { throw new SystemException("Invalid token" + currentToken()); }
        } 
    }
}
