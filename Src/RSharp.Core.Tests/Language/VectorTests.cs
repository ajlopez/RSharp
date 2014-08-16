namespace RSharp.Core.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Language;

    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void CreateVectorWithIntegers()
        {
            Vector v = new Vector(new object[] { 1, 2, 3 });

            Assert.AreEqual(3, v.Length);
            Assert.AreEqual(1, v[0]);
            Assert.AreEqual(2, v[1]);
            Assert.AreEqual(3, v[2]);
        }
    }
}
