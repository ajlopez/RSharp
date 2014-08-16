namespace RSharp.Core.Tests.Expressions
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Expressions;

    [TestClass]
    public class EvaluateTests
    {
        [TestMethod]
        public void EvaluateConstantExpression()
        {
            Assert.AreEqual(1, (new ConstantExpression(1)).Evaluate(null));
            Assert.AreEqual("foo", (new ConstantExpression("foo")).Evaluate(null));
        }

        [TestMethod]
        public void EvaluateNameExpression()
        {
            Context context = new Context();

            context.SetValue("one", 1);
            context.SetValue("name", "Adam");

            Assert.AreEqual(1, (new NameExpression("one")).Evaluate(context));
            Assert.AreEqual("Adam", (new NameExpression("name")).Evaluate(context));
            Assert.IsNull((new NameExpression("foo")).Evaluate(context));
        }
    }
}
