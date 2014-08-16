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

            Assert.IsNotNull(token);
            IsToken(token, TokenType.Name, "foo");

            Assert.IsNull(lexer.NextToken());
        }

        private static void IsToken(Token token, TokenType type, string value)
        {
            Assert.AreEqual(token.Value, value);
            Assert.AreEqual(token.Type, type);
        }
    }
}
