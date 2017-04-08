namespace RSharp.Core.Tests.Functions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Expressions;
    using System.Collections.Generic;
    using RSharp.Core.Functions;

    [TestClass]
    public class DefinedFunctionTests
    {
        [TestMethod]
        public void EvaluateUsingArgumentAndOriginalContext()
        {
            Context context = new Context();
            context.SetValue("return", new Return());
            IList<string> arguments = new string[] { "a" };
            IExpression body = new CallExpression(new NameExpression("return"), new IExpression[] { new NameExpression("a") });

            DefinedFunction dfunc = new DefinedFunction(context, arguments, body);

            var result = dfunc.Apply(null, new object[] { 42 });

            Assert.IsNotNull(result);
            Assert.AreEqual(42, result);
        }
    }
}
