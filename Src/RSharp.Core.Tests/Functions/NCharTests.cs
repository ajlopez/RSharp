namespace RSharp.Core.Tests.Functions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Functions;
    using RSharp.Core.Language;

    [TestClass]
    public class NCharTests
    {
        [TestMethod]
        public void NCharOfAnString()
        {
            NChar fn = new NChar();

            var result = fn.Apply(null, new object[] { "hello" });

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result);
        }
    }
}
