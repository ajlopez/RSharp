namespace RSharp.Core.Tests.Expressions
{
    using System;
    using System.Collections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Expressions;

    [TestClass]
    public class CompositeExpressionTests
    {
        [TestMethod]
        public void EvaluateCompositeWithoutReturnReturnsNull()
        {
            CompositeExpression expression = new CompositeExpression(new IExpression[] { });

            Assert.IsNull(expression.Evaluate(null));
        }
    }
}
