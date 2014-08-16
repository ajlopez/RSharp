namespace RSharp.Core.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
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
    }
}
