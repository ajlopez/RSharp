namespace RSharp.Core.Tests.Interpreter
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Interpreter;
    using RSharp.Core.Expressions;

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
        public void ParseNameExpression()
        {
            var parser = new Parser("foo");

            var expr = parser.ParseExpression();

            IsNameExpression(expr, "foo");

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
