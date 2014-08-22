namespace RSharp.Core.Tests.Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Expressions;
    using RSharp.Core.Functions;
    using RSharp.Core.Interpreter;
    using RSharp.Core.Language;

    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void ParseIntegerExpression()
        {
            var parser = new Parser("123");

            var expr = parser.ParseExpression();

            IsConstantExpression(expr, 123);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseIntegerExpressionWithEndOfLine()
        {
            var parser = new Parser("123\r\n");

            var expr = parser.ParseExpression();

            IsConstantExpression(expr, 123);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseIntegerExpressionSkippingEndOfLine()
        {
            var parser = new Parser("\r\n123");

            var expr = parser.ParseExpression();

            IsConstantExpression(expr, 123);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseNameExpression()
        {
            var parser = new Parser("foo");

            var expr = parser.ParseExpression();

            IsNameExpression(expr, "foo");

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseAddExpression()
        {
            var parser = new Parser("1+2");

            var expr = parser.ParseExpression();

            Assert.IsNotNull(expr);
            Assert.IsInstanceOfType(expr, typeof(AddExpression));

            var addexpr = (AddExpression)expr;

            Assert.IsNotNull(addexpr.LeftExpression);
            Assert.IsNotNull(addexpr.RightExpression);
            Assert.IsInstanceOfType(addexpr.LeftExpression, typeof(ConstantExpression));
            Assert.AreEqual(1, ((ConstantExpression)addexpr.LeftExpression).Value);
            Assert.IsInstanceOfType(addexpr.RightExpression, typeof(ConstantExpression));
            Assert.AreEqual(2, ((ConstantExpression)addexpr.RightExpression).Value);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseSubtractExpression()
        {
            var parser = new Parser("1-2");

            var expr = parser.ParseExpression();

            Assert.IsNotNull(expr);
            Assert.IsInstanceOfType(expr, typeof(SubtractExpression));

            var subexpr = (SubtractExpression)expr;

            Assert.IsNotNull(subexpr.LeftExpression);
            Assert.IsNotNull(subexpr.RightExpression);
            Assert.IsInstanceOfType(subexpr.LeftExpression, typeof(ConstantExpression));
            Assert.AreEqual(1, ((ConstantExpression)subexpr.LeftExpression).Value);
            Assert.IsInstanceOfType(subexpr.RightExpression, typeof(ConstantExpression));
            Assert.AreEqual(2, ((ConstantExpression)subexpr.RightExpression).Value);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseMultiplyExpression()
        {
            var parser = new Parser("2*3");

            var expr = parser.ParseExpression();

            Assert.IsNotNull(expr);
            Assert.IsInstanceOfType(expr, typeof(MultiplyExpression));

            var subexpr = (MultiplyExpression)expr;

            Assert.IsNotNull(subexpr.LeftExpression);
            Assert.IsNotNull(subexpr.RightExpression);
            Assert.IsInstanceOfType(subexpr.LeftExpression, typeof(ConstantExpression));
            Assert.AreEqual(2, ((ConstantExpression)subexpr.LeftExpression).Value);
            Assert.IsInstanceOfType(subexpr.RightExpression, typeof(ConstantExpression));
            Assert.AreEqual(3, ((ConstantExpression)subexpr.RightExpression).Value);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseAndEvaluateCallExpression()
        {
            var parser = new Parser("c(1,2,3)");

            var expr = parser.ParseExpression();

            Assert.IsNotNull(expr);
            Assert.IsInstanceOfType(expr, typeof(CallExpression));

            Context context = new Context();
            context.SetValue("c", new MakeVector());

            var result = expr.Evaluate(context);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(2, vector[1]);
            Assert.AreEqual(3, vector[2]);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void RaiseExpectedComma()
        {
            var parser = new Parser("c(1 2 3)");

            try
            {
                parser.ParseExpression();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ParserException));
                Assert.AreEqual("Expected ','", ex.Message);
            }
        }

        private static void IsConstantExpression(IExpression expr, object value)
        {
            Assert.IsNotNull(expr);
            Assert.IsInstanceOfType(expr, typeof(ConstantExpression));
            Assert.AreEqual(value, ((ConstantExpression)expr).Value);
        }

        private static void IsNameExpression(IExpression expr, string name)
        {
            Assert.IsNotNull(expr);
            Assert.IsInstanceOfType(expr, typeof(NameExpression));
            Assert.AreEqual(name, ((NameExpression)expr).Name);
        }
    }
}
