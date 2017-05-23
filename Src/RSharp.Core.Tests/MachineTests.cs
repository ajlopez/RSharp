namespace RSharp.Core.Tests
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

    [TestClass]
    public class MachineTests
    {
        [TestMethod]
        public void EvaluateMakeVector()
        {
            Machine machine = new Machine();
            Parser parser = new Parser("c(1,2,3)");
            IExpression expr = parser.ParseExpression();

            var result = machine.Evaluate(expr);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(2, vector[1]);
            Assert.AreEqual(3, vector[2]);
        }

        [TestMethod]
        public void InitialContext()
        {
            Machine machine = new Machine();

            var context = machine.Context;

            Assert.IsNotNull(context);
            
            Assert.IsNotNull(context.GetValue("return"));
            Assert.IsInstanceOfType(context.GetValue("return"), typeof(IFunction));
            Assert.IsInstanceOfType(context.GetValue("return"), typeof(Return));
            
            Assert.IsNotNull(context.GetValue("c"));
            Assert.IsInstanceOfType(context.GetValue("c"), typeof(IFunction));
            Assert.IsInstanceOfType(context.GetValue("c"), typeof(MakeVector));

            Assert.IsNotNull(context.GetValue("length"));
            Assert.IsInstanceOfType(context.GetValue("length"), typeof(IFunction));
            Assert.IsInstanceOfType(context.GetValue("length"), typeof(Length));

            Assert.IsNotNull(context.GetValue("substring"));
            Assert.IsInstanceOfType(context.GetValue("substring"), typeof(IFunction));
            Assert.IsInstanceOfType(context.GetValue("substring"), typeof(Substring));

            Assert.IsNotNull(context.GetValue("paste"));
            Assert.IsInstanceOfType(context.GetValue("paste"), typeof(IFunction));
            Assert.IsInstanceOfType(context.GetValue("paste"), typeof(Paste));
        }
    }
}
