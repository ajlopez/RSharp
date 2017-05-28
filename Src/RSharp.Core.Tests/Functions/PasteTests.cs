namespace RSharp.Core.Tests.Functions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Functions;
    using System.Collections.Generic;

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

            var result = fn.Apply(null, new object[] { "foo", "bar" }, new Dictionary<string, object>() { { "sep",  "" } });

            Assert.IsNotNull(result);
            Assert.AreEqual("foobar", result);
        }
    }
}
