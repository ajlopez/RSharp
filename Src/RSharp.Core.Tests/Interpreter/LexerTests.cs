namespace RSharp.Core.Tests.Interpreter
{
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
        public void GetNameSkippingLineComments()
        {
            Lexer lexer = new Lexer("foo # this is a comment\n# this is another comment");

            var token = lexer.NextToken();

            IsToken(token, TokenType.Name, "foo");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetString()
        {
            Lexer lexer = new Lexer("\"foo\"");

            var token = lexer.NextToken();

            IsToken(token, TokenType.String, "foo");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetLogicalFalse()
        {
            Lexer lexer = new Lexer("FALSE");

            var token = lexer.NextToken();

            IsToken(token, TokenType.Logical, "FALSE");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetLogicalFalseShortName()
        {
            Lexer lexer = new Lexer("F");

            var token = lexer.NextToken();

            IsToken(token, TokenType.Logical, "FALSE");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetLogicalTrue()
        {
            Lexer lexer = new Lexer("TRUE");

            var token = lexer.NextToken();

            IsToken(token, TokenType.Logical, "TRUE");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetLogicalTrueShortName()
        {
            Lexer lexer = new Lexer("T");

            var token = lexer.NextToken();

            IsToken(token, TokenType.Logical, "TRUE");

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
        public void GetReal()
        {
            Lexer lexer = new Lexer("3.14159");

            var token = lexer.NextToken();

            IsToken(token, TokenType.Real, "3.14159");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetDelimiters()
        {
            Lexer lexer = new Lexer(".,;(){}");

            IsToken(lexer.NextToken(), TokenType.Delimiter, ".");
            IsToken(lexer.NextToken(), TokenType.Delimiter, ",");
            IsToken(lexer.NextToken(), TokenType.Delimiter, ";");
            IsToken(lexer.NextToken(), TokenType.Delimiter, "(");
            IsToken(lexer.NextToken(), TokenType.Delimiter, ")");
            IsToken(lexer.NextToken(), TokenType.Delimiter, "{");
            IsToken(lexer.NextToken(), TokenType.Delimiter, "}");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetSquareBracketsAsDelimiters()
        {
            Lexer lexer = new Lexer("[]");

            IsToken(lexer.NextToken(), TokenType.Delimiter, "[");
            IsToken(lexer.NextToken(), TokenType.Delimiter, "]");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetNewLine()
        {
            Lexer lexer = new Lexer("\n");

            IsToken(lexer.NextToken(), TokenType.EndOfLine, "\n");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetCarriageReturnNewLine()
        {
            Lexer lexer = new Lexer("\r\n");

            IsToken(lexer.NextToken(), TokenType.EndOfLine, "\r\n");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetCarriageReturn()
        {
            Lexer lexer = new Lexer("\r");

            IsToken(lexer.NextToken(), TokenType.EndOfLine, "\r");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetPlus()
        {
            Lexer lexer = new Lexer("+");

            IsToken(lexer.NextToken(), TokenType.Operator, "+");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetMinus()
        {
            Lexer lexer = new Lexer("-");

            IsToken(lexer.NextToken(), TokenType.Operator, "-");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetAsterisk()
        {
            Lexer lexer = new Lexer("*");

            IsToken(lexer.NextToken(), TokenType.Operator, "*");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetSlash()
        {
            Lexer lexer = new Lexer("/");

            IsToken(lexer.NextToken(), TokenType.Operator, "/");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetEqualAsOperator()
        {
            Lexer lexer = new Lexer("=");

            IsToken(lexer.NextToken(), TokenType.Operator, "=");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetLeftArrow()
        {
            Lexer lexer = new Lexer("<-");

            IsToken(lexer.NextToken(), TokenType.Operator, "<-");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetOperators()
        {
            var operators = new string[] { "+", "-", "*", "/", "^", ":", ">", "<", ">=", "<=", "==", "%%" };
            var text = string.Empty;

            foreach (var oper in operators)
                text += oper + " ";

            Lexer lexer = new Lexer(text);

            foreach (var oper in operators)
            {
                var result = lexer.NextToken();

                Assert.IsNotNull(result);
                Assert.AreEqual(TokenType.Operator, result.Type);
                Assert.AreEqual(oper, result.Value);
            }

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetRightArrow()
        {
            Lexer lexer = new Lexer("->");

            IsToken(lexer.NextToken(), TokenType.Operator, "->");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void UnexpectedCharacter()
        {
            Lexer lexer = new Lexer("@");

            try
            {
                lexer.NextToken();
                Assert.Fail();
            }
            catch (LexerException ex)
            {
                Assert.AreEqual("Unexpected '@'", ex.Message);
            }
        }

        private static void IsToken(Token token, TokenType type, string value)
        {
            Assert.IsNotNull(token);
            Assert.AreEqual(value, token.Value);
            Assert.AreEqual(type, token.Type);
        }
    }
}
