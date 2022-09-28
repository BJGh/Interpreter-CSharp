using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
namespace Interpreter
{
    class Terminal
    {
        private readonly TokenType returnTokenType;
        private readonly Regex pattern;
        private readonly int priority;

        public Terminal(TokenType returnTokenType, String pattern) : this(returnTokenType, pattern, 0 ) { }
        
        public Terminal(TokenType returnTokenType, String pattern, int priority)
        {
            this.returnTokenType = returnTokenType;
            this.pattern = new Regex(pattern);
            this.priority = priority;
        }

        public Boolean termMatches(String charSequence) { return  pattern.IsMatch(charSequence);  }

        // вместо идентификатора
        public String getTokenType()
        {
            return Convert.ToString( returnTokenType);
        }
        public int getPriority()
        {
            return priority;
        }
        

    }
}
