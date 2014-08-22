namespace RSharp.Core.Tests.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Expressions;
    using RSharp.Core.Functions;
    using RSharp.Core.Language;

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

        [TestMethod]
        public void EvaluateMakeVectorCallExpression()
        {
            Context context = new Context();

            context.SetValue("one", 1);
            context.SetValue("two", 2);
            context.SetValue("three", 3);
            context.SetValue("c", new MakeVector());

            var expr = new CallExpression(new NameExpression("c"), new IExpression[] { new NameExpression("one"), new NameExpression("two"), new NameExpression("three") });

            var result = expr.Evaluate(context);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(2, vector[1]);
            Assert.AreEqual(3, vector[2]);
        }

        [TestMethod]
        public void EvaluateAddExpressionWithTwoIntegers()
        {
            Context context = new Context();

            context.SetValue("one", 1);
            context.SetValue("two", 2);

            var expr = new AddExpression(new NameExpression("one"), new NameExpression("two"));

            var result = expr.Evaluate(context);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void EvaluateSubtractExpressionWithTwoIntegers()
        {
            Context context = new Context();

            context.SetValue("one", 1);
            context.SetValue("two", 2);

            var expr = new SubtractExpression(new NameExpression("one"), new NameExpression("two"));

            var result = expr.Evaluate(context);

            Assert.IsNotNull(result);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void EvaluateMultiplyExpressionWithTwoIntegers()
        {
            Context context = new Context();

            context.SetValue("two", 2);
            context.SetValue("three", 3);

            var expr = new MultiplyExpression(new NameExpression("two"), new NameExpression("three"));

            var result = expr.Evaluate(context);

            Assert.IsNotNull(result);
            Assert.AreEqual(6, result);
        }
    }
}
