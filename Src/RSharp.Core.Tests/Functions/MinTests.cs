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

        [TestMethod]
        public void MinOfTwoReals()
        {
            IFunction fn = new Min();

            var result = fn.Apply(null, new object[] { 1.5, 42.5 }, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(1.5, result);
        }

        [TestMethod]
        public void MinOfThreeReals()
        {
            IFunction fn = new Min();

            var result = fn.Apply(null, new object[] { 42.0, 3.14159, 2.5 }, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(2.5, result);
        }
    }
}
