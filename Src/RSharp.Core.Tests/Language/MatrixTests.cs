namespace RSharp.Core.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Language;

    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void CreateMatrixWithTwoVectors()
        {
            Vector v1 = new Vector(new object[] { 1, 2, 3 });
            Vector v2 = new Vector(new object[] { 4, 5, 6 });

            Matrix matrix = new Matrix(new Vector[] { v1, v2 });

            Assert.AreEqual(1, matrix[0, 0]);
            Assert.AreEqual(2, matrix[0, 1]);
            Assert.AreEqual(3, matrix[0, 2]);

            Assert.AreEqual(4, matrix[1, 0]);
            Assert.AreEqual(5, matrix[1, 1]);
            Assert.AreEqual(6, matrix[1, 2]);
        }
    }
}
