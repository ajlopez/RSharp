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
    using RSharp.Core.Operations;

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
        public void ParseTwoIntegerExpressions()
        {
            var parser = new Parser("123 456");

            var expr = parser.ParseExpression();

            IsConstantExpression(expr, 123);

            expr = parser.ParseExpression();

            IsConstantExpression(expr, 456);

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
            Assert.IsInstanceOfType(expr, typeof(BinaryExpression));

            var addexpr = (BinaryExpression)expr;

            Assert.IsNotNull(addexpr.LeftExpression);
            Assert.IsNotNull(addexpr.RightExpression);
            Assert.IsNotNull(addexpr.BinaryOperation);
            Assert.IsInstanceOfType(addexpr.BinaryOperation, typeof(AddOperation));
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
            Assert.IsInstanceOfType(expr, typeof(BinaryExpression));

            var subexpr = (BinaryExpression)expr;

            Assert.IsNotNull(subexpr.LeftExpression);
            Assert.IsNotNull(subexpr.RightExpression);
            Assert.IsNotNull(subexpr.BinaryOperation);
            Assert.IsInstanceOfType(subexpr.BinaryOperation, typeof(SubtractOperation));
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
            Assert.IsInstanceOfType(expr, typeof(BinaryExpression));

            var multexpr = (BinaryExpression)expr;

            Assert.IsNotNull(multexpr.LeftExpression);
            Assert.IsNotNull(multexpr.RightExpression);
            Assert.IsNotNull(multexpr.BinaryOperation);
            Assert.IsInstanceOfType(multexpr.BinaryOperation, typeof(MultiplyOperation));
            Assert.IsInstanceOfType(multexpr.LeftExpression, typeof(ConstantExpression));
            Assert.AreEqual(2, ((ConstantExpression)multexpr.LeftExpression).Value);
            Assert.IsInstanceOfType(multexpr.RightExpression, typeof(ConstantExpression));
            Assert.AreEqual(3, ((ConstantExpression)multexpr.RightExpression).Value);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseDivideExpression()
        {
            var parser = new Parser("4/5");

            var expr = parser.ParseExpression();

            Assert.IsNotNull(expr);
            Assert.IsInstanceOfType(expr, typeof(BinaryExpression));

            var multexpr = (BinaryExpression)expr;

            Assert.IsNotNull(multexpr.LeftExpression);
            Assert.IsNotNull(multexpr.RightExpression);
            Assert.IsNotNull(multexpr.BinaryOperation);
            Assert.IsInstanceOfType(multexpr.BinaryOperation, typeof(DivideOperation));
            Assert.IsInstanceOfType(multexpr.LeftExpression, typeof(ConstantExpression));
            Assert.AreEqual(4, ((ConstantExpression)multexpr.LeftExpression).Value);
            Assert.IsInstanceOfType(multexpr.RightExpression, typeof(ConstantExpression));
            Assert.AreEqual(5, ((ConstantExpression)multexpr.RightExpression).Value);

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

        [TestMethod]
        public void ParseAssignExpression()
        {
            var parser = new Parser("a <- 1");

            var expr = parser.ParseExpression();

            Assert.IsNotNull(expr);
            Assert.IsInstanceOfType(expr, typeof(AssignExpression));

            var aexpr = (AssignExpression)expr;
            Assert.AreEqual("a", aexpr.Name);
            Assert.IsNotNull(aexpr.Expression);
            IsConstantExpression(aexpr.Expression, 1);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseSequenceExpression()
        {
            var parser = new Parser("1:20");

            var expr = parser.ParseExpression();

            Assert.IsNotNull(expr);
            Assert.IsInstanceOfType(expr, typeof(BinaryExpression));

            var bexpr = (BinaryExpression)expr;
            Assert.IsInstanceOfType(bexpr.BinaryOperation, typeof(SequenceOperation));
            IsConstantExpression(bexpr.LeftExpression, 1);
            IsConstantExpression(bexpr.RightExpression, 20);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseInverseAssignExpression()
        {
            var parser = new Parser("1 -> a");

            var expr = parser.ParseExpression();

            Assert.IsNotNull(expr);
            Assert.IsInstanceOfType(expr, typeof(AssignExpression));

            var aexpr = (AssignExpression)expr;
            Assert.AreEqual("a", aexpr.Name);
            Assert.IsNotNull(aexpr.Expression);
            IsConstantExpression(aexpr.Expression, 1);

            Assert.IsNull(parser.ParseExpression());
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
