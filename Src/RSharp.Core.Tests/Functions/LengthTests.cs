namespace RSharp.Core.Tests.Functions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Functions;
    using RSharp.Core.Language;

    [TestClass]
    public class LengthTests
    {
        [TestMethod]
        public void LengthOfAVector()
        {
            Length fn = new Length();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = fn.Apply(null, new object[] { v });

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result);
        }
    }
}
