namespace RSharp.Core.Tests.Functions
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Functions;
    using RSharp.Core.Language;

    [TestClass]
    public class RepTests
    {
        [TestMethod]
        public void RepTwice()
        {
            var fn = new Rep();

            var result = fn.Apply(null, new object[] { "foo", 2 }, null);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(2, vector.Length);
            Assert.AreEqual("foo", vector[0]);
            Assert.AreEqual("foo", vector[0]);
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
