namespace RSharp.Core.Tests.Expressions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Expressions;
    using RSharp.Core.Functions;

    [TestClass]
    public class FunctionExpressionTests
    {
        [TestMethod]
        public void EvaluateFunctionExpression()
        {
            IList<string> arguments = new string[] { "a", "b" };
            IExpression body = new CompositeExpression(new IExpression[] { });

            FunctionExpression expression = new FunctionExpression(arguments, body);

            var result = expression.Evaluate(null);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(DefinedFunction));

            DefinedFunction dfunc = (DefinedFunction)result;

            Assert.AreSame(arguments, dfunc.Arguments);
            Assert.AreSame(body, dfunc.Expression);
        }
    }
}
