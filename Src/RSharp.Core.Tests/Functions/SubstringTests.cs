namespace RSharp.Core.Tests.Functions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Functions;

    [TestClass]
    public class SubstringTests
    {
        [TestMethod]
        public void SubstringTest()
        {
            var fn = new Substring();

            var result = fn.Apply(null, new object[] { "Equator", 3, 5 });

            Assert.IsNotNull(result);
            Assert.AreEqual("uat", result);
        }
    }
}
