namespace RSharp.Core.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Expressions;
    using RSharp.Core.Functions;
    using RSharp.Core.Interpreter;
    using RSharp.Core.Language;

    [TestClass]
    public class EvaluateTests
    {
        [TestMethod]
        public void EvaluateMakeVector()
        {
            var result = Evaluate("c(1,2,3)");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(2, vector[1]);
            Assert.AreEqual(3, vector[2]);
        }

        [TestMethod]
        public void EvaluateMakeVectorGetElement()
        {
            var result = Evaluate("c(1,2,3)[1]");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void EvaluateVectorLength()
        {
            var result = Evaluate("length(c(1,2,3))");

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void EvaluateStringLength()
        {
            var result = Evaluate("length(\"foobar\")");

            Assert.IsNotNull(result);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void EvaluateNChar()
        {
            var result = Evaluate("nchar(\"foobar\")");

            Assert.IsNotNull(result);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void EvaluateSubstring()
        {
            var result = Evaluate("substring(\"Equator\", 3, 5)");

            Assert.IsNotNull(result);
            Assert.AreEqual("uat", result);
        }

        [TestMethod]
        public void EvaluatePaste()
        {
            var result = Evaluate("paste(\"foo\", \"bar\")");

            Assert.IsNotNull(result);
            Assert.AreEqual("foo bar", result);
        }

        [TestMethod]
        public void EvaluateMinWithIntegers()
        {
            var result = Evaluate("min(1,2,42)");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void EvaluateMinWithIntegersAndReal()
        {
            var result = Evaluate("min(1.5,2,42)");

            Assert.IsNotNull(result);
            Assert.AreEqual(1.5, result);
        }

        [TestMethod]
        public void EvaluateMaxWithIntegers()
        {
            var result = Evaluate("max(1,2,42)");

            Assert.IsNotNull(result);
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void EvaluateMaxWithIntegersAndReal()
        {
            var result = Evaluate("max(1,2,42, 314.159)");

            Assert.IsNotNull(result);
            Assert.AreEqual(314.159, result);
        }

        [TestMethod]
        public void EvaluatePasteUsingSep()
        {
            var result = Evaluate("paste(\"foo\", \"bar\", sep=\"\")");

            Assert.IsNotNull(result);
            Assert.AreEqual("foobar", result);
        }

        [TestMethod]
        public void EvaluateSimpleArithmeticExpressions()
        {
            Assert.AreEqual(3, Evaluate("1 + 2"));
            Assert.AreEqual(6, Evaluate("2 * 3"));
            Assert.AreEqual(8, Evaluate("10 - 2"));
            Assert.AreEqual(2, Evaluate("4 / 2"));
            Assert.AreEqual(1 / 2.0, Evaluate("1/2"));
        }

        [TestMethod]
        public void EvaluateArithmeticExpressionsUsingPrecedence()
        {
            Assert.AreEqual(7, Evaluate("1 + 2 * 3"));
            Assert.AreEqual(7, Evaluate("2 * 3 + 1"));
            Assert.AreEqual(9, Evaluate("10 - 2 / 2"));
            Assert.AreEqual(3, Evaluate("4 / 2 + 1"));
            Assert.AreEqual(1 / 2.0 * 3, Evaluate("1/2 * 3"));
        }

        [TestMethod]
        public void EvaluateArithmeticExpressionsUsingParenthesis()
        {
            Assert.AreEqual(9, Evaluate("(1 + 2) * 3"));
            Assert.AreEqual(8, Evaluate("2 * (3 + 1)"));
            Assert.AreEqual(4, Evaluate("(10 - 2) / 2"));
            Assert.AreEqual(4 / 3.0, Evaluate("4 / (2 + 1)"));
            Assert.AreEqual(1 / 6.0, Evaluate("1/(2 * 3)"));
        }

        [TestMethod]
        public void EvaluateRange()
        {
            var result = Evaluate("1:20");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;
            Assert.AreEqual(20, vector.Length);

            for (int k = 1; k <= 20; k++)
                Assert.AreEqual(k, vector[k - 1]);
        }

        [TestMethod]
        public void EvaluateRangeWithExpression()
        {
            var result = Evaluate("1:(10+10)");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;
            Assert.AreEqual(20, vector.Length);

            for (int k = 1; k <= 20; k++)
                Assert.AreEqual(k, vector[k - 1]);
        }

        [TestMethod]
        public void EvaluateAssignment()
        {
            var machine = new Machine();
            var result = Evaluate(machine, "x <- 42");

            Assert.IsNotNull(result);
            Assert.AreEqual(42, result);
            Assert.AreEqual(42, machine.Context.GetValue("x"));
        }

        [TestMethod]
        public void EvaluateFunctionExpression()
        {
            var result = Evaluate("function (a) return(a+1)");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(DefinedFunction));
        }

        [TestMethod]
        public void EvaluateCallFunctionExpression()
        {
            var result = Evaluate("function (a) { return(a+1) } (1)");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result);
        }

        private static object Evaluate(string text)
        {
            return Evaluate(new Machine(), text);
        }

        private static object Evaluate(Machine machine, string text)
        {
            Parser parser = new Parser(text);
            IExpression expr = parser.ParseExpression();

            var result = machine.Evaluate(expr);

            Assert.IsNull(parser.ParseExpression());

            return result;
        }
    }
}
