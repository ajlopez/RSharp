namespace RSharp.Core.Tests.Functions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Functions;
    using RSharp.Core.Language;

    [TestClass]
    public class MinTests
    {
        [TestMethod]
        public void MinOfTwoIntegers()
        {
            IFunction fn = new Min();

            var result = fn.Apply(null, new object[] { 1, 42 }, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void MinOfThreeIntegers()
        {
            IFunction fn = new Min();

            var result = fn.Apply(null, new object[] { 42, 1, 2 }, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }
    }
}
