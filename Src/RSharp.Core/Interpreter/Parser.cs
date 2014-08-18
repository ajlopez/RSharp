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
        private Stack<Token> tokens = new Stack<Token>();

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

        public IExpression ParseExpression()
        {
            IExpression expr = this.ParseTerm();

            if (expr == null)
                return null;

            Token token;

            for (token = this.NextToken(); token != null && token.Type == TokenType.Operator && (token.Value == "+" || token.Value == "-"); token = this.NextToken())
            {
                if (token.Value == "+")
                    expr = new AddExpression(expr, this.ParseTerm());
                else
                    expr = new SubtractExpression(expr, this.ParseTerm());
            }

            this.PushToken(token);

            return expr;
        }

        private IExpression ParseTerm()
        {
            IExpression expr = this.ParseSimpleTerm();

            if (expr == null)
                return null;

            if (!this.TryNextToken(TokenType.Delimiter, "("))
                return expr;

            IList<IExpression> exprs = new List<IExpression>();

            while (!this.TryNextToken(TokenType.Delimiter, ")"))
            {
                if (exprs.Count > 0)
                    this.NextToken(TokenType.Delimiter, ",");

                exprs.Add(this.ParseExpression());
            }

            return new CallExpression(expr, exprs);
        }

        private IExpression ParseSimpleTerm()
        {
            var token = this.NextToken();

            while (token != null && token.Type == TokenType.EndOfLine)
                token = this.NextToken();

            if (token == null)
                return null;

            if (token.Type == TokenType.Name)
                return new NameExpression(token.Value);

            return new ConstantExpression(int.Parse(token.Value, CultureInfo.InvariantCulture));
        }

        private Token NextToken()
        {
            if (this.tokens.Count > 0)
                return this.tokens.Pop();

            return this.lexer.NextToken();
        }

        private void PushToken(Token token)
        {
            this.tokens.Push(token);
        }

        private void NextToken(TokenType type, string value)
        {
            var token = this.NextToken();

            if (token == null || token.Type != type || token.Value != value)
                throw new ParserException(string.Format("Expected '{0}'", value));
        }

        private bool TryNextToken(TokenType type, string value)
        {
            var token = this.NextToken();

            if (token != null && token.Type == type && token.Value == value)
                return true;

            this.PushToken(token);

            return false;
        }
    }
}
