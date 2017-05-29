namespace RSharp.Core.Tests.Functions
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Functions;

    [TestClass]
    public class PasteTests
    {
        [TestMethod]
        public void PasteOneString()
        {
            var fn = new Paste();

            var result = fn.Apply(null, new object[] { "foo" }, null);

            Assert.IsNotNull(result);
            Assert.AreEqual("foo", result);
        }

        [TestMethod]
        public void PasteTwoStrings()
        {
            var fn = new Paste();

            var result = fn.Apply(null, new object[] { "foo", "bar" }, null);

            Assert.IsNotNull(result);
            Assert.AreEqual("foo bar", result);
        }

        [TestMethod]
        public void PasteTwoStringsUsingEmptySeparator()
        {
            var fn = new Paste();

            var result = fn.Apply(null, new object[] { "foo", "bar" }, new Dictionary<string, object>() { { "sep",  string.Empty } });

            Assert.IsNotNull(result);
            Assert.AreEqual("foobar", result);
        }
    }
}
