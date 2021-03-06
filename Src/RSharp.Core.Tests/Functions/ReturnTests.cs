﻿namespace RSharp.Core.Tests.Functions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Functions;

    [TestClass]
    public class ReturnTests
    {
        [TestMethod]
        public void ReturnInteger()
        {
            Context context = new Context();

            Assert.IsFalse(context.HasReturnValue);

            Return fn = new Return();

            var result = fn.Apply(context, new object[] { 42 }, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(42, result);
            Assert.IsTrue(context.HasReturnValue);
            Assert.AreEqual(42, context.ReturnValue);
        }
    }
}
