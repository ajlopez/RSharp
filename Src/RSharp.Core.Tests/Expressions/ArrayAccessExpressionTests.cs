namespace RSharp.Core.Tests.Expressions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Expressions;
    using RSharp.Core.Functions;
    using RSharp.Core.Language;

    [TestClass]
    public class ArrayAccessExpressionTests
    {
        [TestMethod]
        public void GetSecondElement()
        {
            Vector vector = new Vector(new object[] { 1, 2, 3 });
            IExpression arrexpr = new ConstantExpression(vector);
            IExpression indexpr = new ConstantExpression(1);

            IExpression expr = new ArrayAccessExpression(arrexpr, new IExpression[] { indexpr });

            Assert.AreEqual(2, expr.Evaluate(null));
        }
    }
}
