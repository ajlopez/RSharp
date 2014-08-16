﻿namespace RSharp.Core.Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    public class Lexer
    {
        private Stack<int> chars = new Stack<int>();
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

            var ch = (char)ich;

            if (char.IsDigit(ch))
                return this.NextInteger(ch);

            if (char.IsLetter(ch))
                return this.NextName(ch);

            return new Token(TokenType.Delimiter, ch.ToString());
        }

        private Token NextInteger(char firstch)
        {
            string value = firstch.ToString();

            int ich;

            for (ich = this.NextChar(); ich >= 0 && char.IsDigit((char)ich); ich = this.NextChar())
                value += ((char)ich).ToString();

            this.PushChar(ich);

            return new Token(TokenType.Integer, value);
        }

        private Token NextName(char firstch)
        {
            string value = firstch.ToString();

            int ich;

            for (ich = this.NextChar(); ich >= 0 && char.IsLetter((char)ich); ich = this.NextChar())
                value += ((char)ich).ToString();

            this.PushChar(ich);

            return new Token(TokenType.Name, value);
        }

        private int NextChar()
        {
            if (this.chars.Count > 0)
                return this.chars.Pop();

            return this.reader.Read();
        }

        private void PushChar(int ich)
        {
            this.chars.Push(ich);
        }
    }
}