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

        [TestMethod]
        public void ToLines()
        {
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var lines = v.ToLines();

            Assert.IsNotNull(lines);
            Assert.AreEqual(1, lines.Count);
            Assert.AreEqual("[1] 1 2 3", lines[0]);
        }

        [TestMethod]
        public void AddInteger()
        {
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = v.Add(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var v2 = (Vector)result;

            Assert.AreEqual(3, v2.Length);
            Assert.AreEqual(v2[0], 2);
            Assert.AreEqual(v2[1], 3);
            Assert.AreEqual(v2[2], 4);
        }

        [TestMethod]
        public void AddVector()
        {
            Vector v = new Vector(new object[] { 1, 2, 3 });
            Vector v2 = new Vector(new object[] { 2, 4, 8 });

            var result = v.Add(v2);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var v3 = (Vector)result;

            Assert.AreEqual(3, v3.Length);
            Assert.AreEqual(3, v3[0]);
            Assert.AreEqual(6, v3[1]);
            Assert.AreEqual(11, v3[2]);
        }
    }
}
