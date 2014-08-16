namespace RSharp.Core.Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    public class Lexer
    {
        private TextReader reader;

        public Lexer(string text)
            : this(new StringReader(text))
        {
        }

        public Lexer(TextReader reader)
        {
            this.reader = reader;
        }

        public Token NextToken()
        {
            int ich = this.NextChar();

            while (ich >= 0 && char.IsWhiteSpace((char)ich))
                ich = this.NextChar();

            if (ich < 0)
                return null;

            string name = ((char)ich).ToString();

            for (ich = this.NextChar(); ich >= 0 && !char.IsWhiteSpace((char)ich); ich = this.NextChar())
                name += ((char)ich).ToString();

            var token = new Token(TokenType.Name, name);

            return token;
        }

        private int NextChar()
        {
            return this.reader.Read();
        }
    }
}
