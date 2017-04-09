namespace RSharp.Core.Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Expressions;
    using RSharp.Core.Operations;

    public class Parser
    {
        private Lexer lexer;
        private Stack<Token> tokens = new Stack<Token>();
        private string[][] binlevels = new string[][] { new string[] { ":" }, new string[] { "+", "-" }, new string[] { "*", "/" } };

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
            IExpression expr = this.ParseBinaryExpression(0);

            if (expr == null)
                return null;

            if (expr is NameExpression && this.TryNextToken(TokenType.Operator, "<-"))
                return new AssignExpression(((NameExpression)expr).Name, this.ParseExpression());

            if (this.TryNextToken(TokenType.Operator, "->"))
                return new AssignExpression(this.ParseName(), expr);

            return expr;
        }

        private IExpression ParseBinaryExpression(int level) 
        {
            if (level >= this.binlevels.Length)
                return this.ParseTerm();

            IExpression expr = this.ParseBinaryExpression(level + 1);

            if (expr == null)
                return null;

            Token token;

            for (token = this.NextToken(); token != null && token.Type == TokenType.Operator && this.binlevels[level].Contains(token.Value); token = this.NextToken())
            {
                if (token.Value == ":")
                    expr = new BinaryExpression(new SequenceOperation(), expr, this.ParseBinaryExpression(level + 1));
                else if (token.Value == "+")
                    expr = new BinaryExpression(new AddOperation(), expr, this.ParseBinaryExpression(level + 1));
                else if (token.Value == "-")
                    expr = new BinaryExpression(new SubtractOperation(), expr, this.ParseBinaryExpression(level + 1));
                else if (token.Value == "*")
                    expr = new BinaryExpression(new MultiplyOperation(), expr, this.ParseBinaryExpression(level + 1));
                else
                    expr = new BinaryExpression(new DivideOperation(), expr, this.ParseBinaryExpression(level + 1));
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

            if (expr is NameExpression && ((NameExpression)expr).Name == "function") 
            {
                IList<string> args = new List<string>();

                foreach (var nexpr in exprs)
                    args.Add(((NameExpression)nexpr).Name);

                return new FunctionExpression(args, this.ParseExpression());
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

            if (token.Type == TokenType.Delimiter && token.Value == "(")
            {
                var expr = this.ParseExpression();
                this.NextToken(TokenType.Delimiter, ")");
                return expr;
            }

            if (token.Type == TokenType.Delimiter && token.Value == "{")
            {
                var expr = this.ParseCompositeExpression();
                this.NextToken(TokenType.Delimiter, "}");
                return expr;
            }

            if (token.Type == TokenType.Name)
                return new NameExpression(token.Value);

            if (token.Type == TokenType.Integer)
                return new ConstantExpression(int.Parse(token.Value, CultureInfo.InvariantCulture));

            this.PushToken(token);

            return null;
        }

        private CompositeExpression ParseCompositeExpression()
        {
            IList<IExpression> expressions = new List<IExpression>();

            for (var expr = this.ParseExpression(); expr != null; expr = this.ParseExpression())
                expressions.Add(expr);

            return new CompositeExpression(expressions);
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

        private string ParseName()
        {
            var token = this.NextToken();

            if (token == null || token.Type != TokenType.Name)
                throw new ParserException("Name expected");

            return token.Value;
        }
    }
}
