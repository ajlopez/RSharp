namespace RSharp.Core.Tests.Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Interpreter;

    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void GetName()
        {
            Lexer lexer = new Lexer("foo");

            var token = lexer.NextToken();

            IsToken(token, TokenType.Name, "foo");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetNameWithSpaces()
        {
            Lexer lexer = new Lexer("  foo   ");

            var token = lexer.NextToken();

            IsToken(token, TokenType.Name, "foo");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetInteger()
        {
            Lexer lexer = new Lexer("42");

            var token = lexer.NextToken();

            IsToken(token, TokenType.Integer, "42");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetIntegerWithSpaces()
        {
            Lexer lexer = new Lexer("   42  ");

            var token = lexer.NextToken();

            IsToken(token, TokenType.Integer, "42");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetDelimiters()
        {
            Lexer lexer = new Lexer(",;()");

            IsToken(lexer.NextToken(), TokenType.Delimiter, ",");
            IsToken(lexer.NextToken(), TokenType.Delimiter, ";");
            IsToken(lexer.NextToken(), TokenType.Delimiter, "(");
            IsToken(lexer.NextToken(), TokenType.Delimiter, ")");

            Assert.IsNull(lexer.NextToken());
        }

        private static void IsToken(Token token, TokenType type, string value)
        {
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Value, value);
            Assert.AreEqual(token.Type, type);
        }
    }
}
