namespace RSharp.Core.Tests.Functions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Functions;

    [TestClass]
    public class NCharTests
    {
        [TestMethod]
        public void NCharOfAnString()
        {
            NChar fn = new NChar();

            var result = fn.Apply(null, new object[] { "hello" }, null);

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result);
        }
    }
}
