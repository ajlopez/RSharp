namespace RSharp.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ContextTests
    {
        [TestMethod]
        public void GetUndefinedValueAsNull()
        {
            var context = new Context();

            Assert.IsNull(context.GetValue("foo"));
        }

        [TestMethod]
        public void SetAndGetValue()
        {
            var context = new Context();

            context.SetValue("one", 1);

            Assert.AreEqual(1, context.GetValue("one"));
        }

        [TestMethod]
        public void SetAndGetValueInChildContext()
        {
            var parent = new Context();
            var context = new Context(parent);

            context.SetValue("one", 1);

            Assert.AreEqual(1, context.GetValue("one"));
            Assert.IsNull(parent.GetValue("one"));
        }

        [TestMethod]
        public void SetValueInParentAndGetValueFromChildContext()
        {
            var parent = new Context();
            var context = new Context(parent);

            parent.SetValue("one", 1);

            Assert.AreEqual(1, context.GetValue("one"));
        }
    }
}
