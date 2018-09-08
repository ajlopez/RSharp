namespace RSharp.Core.Tests.Functions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Functions;

    [TestClass]
    public class MaxTests
    {
        [TestMethod]
        public void MaxOfTwoIntegers()
        {
            IFunction fn = new Max();

            var result = fn.Apply(null, new object[] { 1, 42 }, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void MaxOfThreeIntegers()
        {
            IFunction fn = new Max();

            var result = fn.Apply(null, new object[] { 42, 1, 2 }, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void MaxOfIntegerAndReal()
        {
            IFunction fn = new Max();

            var result = fn.Apply(null, new object[] { 1.5, 42 }, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void MaxOfTwoRealsAndOneIntegers()
        {
            IFunction fn = new Max();

            var result = fn.Apply(null, new object[] { 42.314, 1, 2 }, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(42.314, result);
        }
    }
}
