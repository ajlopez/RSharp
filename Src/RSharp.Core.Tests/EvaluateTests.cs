namespace RSharp.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Expressions;
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

        private static object Evaluate(string text)
        {
            Machine machine = new Machine();
            Parser parser = new Parser(text);
            IExpression expr = parser.ParseExpression();

            var result = machine.Evaluate(expr);

            Assert.IsNull(parser.ParseExpression());

            return result;
        }
    }
}
