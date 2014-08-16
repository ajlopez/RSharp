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

        private static void IsConstantExpression(ConstantExpression expr, object value)
        {
            Assert.IsNotNull(expr);
            Assert.AreEqual(value, expr.Value);
        }
    }
}
