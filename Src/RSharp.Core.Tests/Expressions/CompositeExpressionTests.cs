namespace RSharp.Core.Tests.Expressions
{
    using System;
    using System.Collections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Expressions;
    using RSharp.Core.Functions;

    [TestClass]
    public class CompositeExpressionTests
    {
        [TestMethod]
        public void EvaluateCompositeWithoutReturnReturnsNull()
        {
            CompositeExpression expression = new CompositeExpression(new IExpression[] { });

            Assert.IsNull(expression.Evaluate(null));
        }

        [TestMethod]
        public void EvaluateCompositeWithReturnValue()
        {
            Context context = new Context();
            context.SetValue("a", 42);
            context.SetValue("return", new Return());

            CompositeExpression expression = new CompositeExpression(new IExpression[] { new CallExpression(new NameExpression("return"), new IExpression[] { new NameExpression("a") }, null) });

            var result = expression.Evaluate(context);

            Assert.IsNotNull(result);
            Assert.AreEqual(42, result);
        }
    }
}
