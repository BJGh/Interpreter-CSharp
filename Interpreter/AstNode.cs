using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class AstNode
    {
        private string name { get; set; }
        private List<AstNode> childs = new List<AstNode>();
        public AstNode(String name)
        {
            this.name = name;
        }
        public void AddChild(AstNode node)
        {
            childs.Add(node);
        }


    }
}
