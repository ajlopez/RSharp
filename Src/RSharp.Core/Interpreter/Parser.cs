namespace RSharp.Core.Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Expressions;
    using System.Globalization;

    public class Parser
    {
        private Lexer lexer;

        public Parser(string text)
            : this(new StringReader(text))
        {
        }

        public Parser(TextReader reader)
            : this(new Lexer(reader))
        {
        }

        public Parser(Lexer lexer)
        {
            this.lexer = lexer;
        }

        public ConstantExpression ParseExpression()
        {
            var token = this.NextToken();

            if (token == null)
                return null;

            return new ConstantExpression(int.Parse(token.Value, CultureInfo.InvariantCulture));
        }

        private Token NextToken()
        {
            return this.lexer.NextToken();
        }
    }
}
