namespace RSharp.Core.Tests.Functions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Functions;

    [TestClass]
    public class PasteTests
    {
        [TestMethod]
        public void PasteOneString()
        {
            var fn = new Paste();

            var result = fn.Apply(null, new object[] { "foo" });

            Assert.IsNotNull(result);
            Assert.AreEqual("foo", result);
        }

        [TestMethod]
        public void PasteTwoStrings()
        {
            var fn = new Paste();

            var result = fn.Apply(null, new object[] { "foo", "bar" });

            Assert.IsNotNull(result);
            Assert.AreEqual("foo bar", result);
        }
    }
}
