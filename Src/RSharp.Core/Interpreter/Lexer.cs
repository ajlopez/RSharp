namespace RSharp.Core.Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Lexer
    {
        private static string[] operators = new string[] { "+", "-", "*", "/", "<-", "->", "^", ":", ">", "<", "==", "<=", ">=", "%%" };
        private static char[] delimiters = new char[] { ',', '(', ')', ';', '{', '}', '[', ']' };

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
            int ich = this.NextCharSkippingWhiteSpaces();

            if (ich < 0)
                return null;

            var ch = (char)ich;

            if (ch == '"')
                return this.NextString();

            if (char.IsDigit(ch))
                return this.NextInteger(ch);

            if (char.IsLetter(ch))
                return this.NextName(ch);

            if (delimiters.Contains(ch))
                return new Token(TokenType.Delimiter, ch.ToString());

            if (operators.Any(op => op[0] == ch))
            {
                foreach (var oper in operators.Where(op => op.Length == 2 && op[0] == ch))
                    if (this.TryNextChar(oper[1]))
                        return new Token(TokenType.Operator, oper);

                var sch = ch.ToString();

                if (operators.Contains(sch))
                    return new Token(TokenType.Operator, sch);
            }

            if (ch == '\n')
                return new Token(TokenType.EndOfLine, "\n");

            if (ch == '\r')
                if (this.TryNextChar('\n'))
                    return new Token(TokenType.EndOfLine, "\r\n");
                else
                    return new Token(TokenType.EndOfLine, "\r");

            throw new LexerException(string.Format("Unexpected '{0}'", ch));
        }

        private static bool IsWhiteSpace(char ch)
        {
            if (ch == '\n' || ch == '\r')
                return false;

            return char.IsWhiteSpace(ch);
        }

        private Token NextInteger(char firstch)
        {
            string value = firstch.ToString();

            int ich;

            for (ich = this.NextChar(); ich >= 0 && char.IsDigit((char)ich); ich = this.NextChar())
                value += ((char)ich).ToString();

            if (ich >= 0 && (char)ich == '.')
                return this.NextReal(value);

            this.PushChar(ich);

            return new Token(TokenType.Integer, value);
        }

        private Token NextReal(string value)
        {
            value += '.';

            int ich;

            for (ich = this.NextChar(); ich >= 0 && char.IsDigit((char)ich); ich = this.NextChar())
                value += ((char)ich).ToString();

            this.PushChar(ich);

            return new Token(TokenType.Real, value);
        }

        private Token NextString()
        {
            string value = string.Empty;

            int ich;

            for (ich = this.NextChar(); ich >= 0; ich = this.NextChar())
            {
                char ch = (char)ich;

                if (ch == '"')
                    break;

                value += ch;
            }

            return new Token(TokenType.String, value);
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

        private int NextCharSkippingWhiteSpaces()
        {
            while (true)
            {
                int ich = this.NextChar();

                while (ich >= 0 && IsWhiteSpace((char)ich))
                    ich = this.NextChar();

                if (ich >= 0 && (char)ich == '#')
                {
                    for (ich = this.NextChar(); ich >= 0; ich = this.NextChar())
                        if ((char)ich == '\n' || (char)ich == '\r')
                            break;

                    continue;
                }

                return ich;
            }
        }

        private void PushChar(int ich)
        {
            this.chars.Push(ich);
        }

        private bool TryNextChar(char ch)
        {
            int ich = this.NextChar();

            if (ich >= 0 && (char)ich == ch)
                return true;

            this.PushChar(ich);

            return false;
        }
    }
}
