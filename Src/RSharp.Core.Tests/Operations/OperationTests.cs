namespace RSharp.Core.Tests.Operations
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Operations;
    using RSharp.Core.Language;

    [TestClass]
    public class OperationTests
    {
        [TestMethod]
        public void AddNumbers()
        {
            AddOperation op = new AddOperation();

            Assert.AreEqual(1 + 2, op.Apply(1, 2));
            Assert.AreEqual(1.2 + 3.4, op.Apply(1.2, 3.4));
            Assert.AreEqual(1 + 2.3, op.Apply(1, 2.3));
            Assert.AreEqual(1.2 + 3, op.Apply(1.2, 3));
        }

        [TestMethod]
        public void AddVectorToInteger()
        {
            AddOperation op = new AddOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = op.Apply(v, 1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(2, vector[0]);
            Assert.AreEqual(3, vector[1]);
            Assert.AreEqual(4, vector[2]);
        }

        [TestMethod]
        public void AddIntegerToVector()
        {
            AddOperation op = new AddOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = op.Apply(1, v);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(2, vector[0]);
            Assert.AreEqual(3, vector[1]);
            Assert.AreEqual(4, vector[2]);
        }

        [TestMethod]
        public void AddVectorToReal()
        {
            AddOperation op = new AddOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = op.Apply(v, 1.5);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(1 + 1.5, vector[0]);
            Assert.AreEqual(2 + 1.5, vector[1]);
            Assert.AreEqual(3 + 1.5, vector[2]);
        }

        [TestMethod]
        public void AddRealToVector()
        {
            AddOperation op = new AddOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = op.Apply(1.5, v);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(1 + 1.5, vector[0]);
            Assert.AreEqual(2 + 1.5, vector[1]);
            Assert.AreEqual(3 + 1.5, vector[2]);
        }

        [TestMethod]
        public void AddVectorToVector()
        {
            AddOperation op = new AddOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });
            Vector v2= new Vector(new object[] { 4, 5 });

            var result = op.Apply(v, v2);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(5, vector[0]);
            Assert.AreEqual(7, vector[1]);
            Assert.AreEqual(7, vector[2]);
        }

        [TestMethod]
        public void SubtractNumbers()
        {
            SubtractOperation op = new SubtractOperation();

            Assert.AreEqual(1 - 2, op.Apply(1, 2));
            Assert.AreEqual(1.2 - 3.4, op.Apply(1.2, 3.4));
            Assert.AreEqual(1 - 2.3, op.Apply(1, 2.3));
            Assert.AreEqual(1.2 - 3, op.Apply(1.2, 3));
        }
    }
}
