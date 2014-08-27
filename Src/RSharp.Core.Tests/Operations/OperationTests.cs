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

        [TestMethod]
        public void SubtractIntegerFromVector()
        {
            SubtractOperation op = new SubtractOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = op.Apply(v, 1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(1, vector[1]);
            Assert.AreEqual(2, vector[2]);
        }

        [TestMethod]
        public void SubtractVectorFromInteger()
        {
            SubtractOperation op = new SubtractOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = op.Apply(1, v);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(-1, vector[1]);
            Assert.AreEqual(-2, vector[2]);
        }

        [TestMethod]
        public void SubtractVectorFromReal()
        {
            SubtractOperation op = new SubtractOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = op.Apply(1.5, v);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(0.5, vector[0]);
            Assert.AreEqual(-0.5, vector[1]);
            Assert.AreEqual(-1.5, vector[2]);
        }

        [TestMethod]
        public void MultiplyNumbers()
        {
            MultiplyOperation op = new MultiplyOperation();

            Assert.AreEqual(3 * 2, op.Apply(3, 2));
            Assert.AreEqual(1.2 * 3.4, op.Apply(1.2, 3.4));
            Assert.AreEqual(4 * 2.3, op.Apply(4, 2.3));
            Assert.AreEqual(1.2 * 3, op.Apply(1.2, 3));
        }

        [TestMethod]
        public void MultiplyVectorToInteger()
        {
            MultiplyOperation op = new MultiplyOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = op.Apply(v, 2);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(2, vector[0]);
            Assert.AreEqual(4, vector[1]);
            Assert.AreEqual(6, vector[2]);
        }

        [TestMethod]
        public void MultiplyIntegerToVector()
        {
            MultiplyOperation op = new MultiplyOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = op.Apply(3, v);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(3, vector[0]);
            Assert.AreEqual(6, vector[1]);
            Assert.AreEqual(9, vector[2]);
        }

        [TestMethod]
        public void MultiplyVectorByReal()
        {
            MultiplyOperation op = new MultiplyOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = op.Apply(v, 1.5);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(1 * 1.5, vector[0]);
            Assert.AreEqual(2 * 1.5, vector[1]);
            Assert.AreEqual(3 * 1.5, vector[2]);
        }

        [TestMethod]
        public void MultiplyRealByVector()
        {
            MultiplyOperation op = new MultiplyOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = op.Apply(1.5, v);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(1 * 1.5, vector[0]);
            Assert.AreEqual(2 * 1.5, vector[1]);
            Assert.AreEqual(3 * 1.5, vector[2]);
        }

        [TestMethod]
        public void MultiplyVectorToVector()
        {
            MultiplyOperation op = new MultiplyOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });
            Vector v2 = new Vector(new object[] { 4, 5 });

            var result = op.Apply(v, v2);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(4, vector[0]);
            Assert.AreEqual(10, vector[1]);
            Assert.AreEqual(12, vector[2]);
        }

        [TestMethod]
        public void DivideNumbers()
        {
            DivideOperation op = new DivideOperation();

            Assert.AreEqual(1 / 2.0, op.Apply(1, 2));
            Assert.AreEqual(2, op.Apply(4, 2));
            Assert.AreEqual(1.2 / 3.4, op.Apply(1.2, 3.4));
            Assert.AreEqual(1 / 2.3, op.Apply(1, 2.3));
            Assert.AreEqual(1.2 / 3, op.Apply(1.2, 3));
        }

        [TestMethod]
        public void DivideVectorByInteger()
        {
            DivideOperation op = new DivideOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = op.Apply(v, 2);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(1 / 2.0, vector[0]);
            Assert.AreEqual(1, vector[1]);
            Assert.AreEqual(3 / 2.0, vector[2]);
        }

        [TestMethod]
        public void DivideIntegerToVector()
        {
            DivideOperation op = new DivideOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = op.Apply(1, v);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(1 / 2.0, vector[1]);
            Assert.AreEqual(1 / 3.0, vector[2]);
        }

        [TestMethod]
        public void DivideVectorToReal()
        {
            DivideOperation op = new DivideOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = op.Apply(v, 1.5);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(1 / 1.5, vector[0]);
            Assert.AreEqual(2 / 1.5, vector[1]);
            Assert.AreEqual(3 / 1.5, vector[2]);
        }

        [TestMethod]
        public void DivideRealToVector()
        {
            DivideOperation op = new DivideOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });

            var result = op.Apply(1.5, v);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(1.5 / 1, vector[0]);
            Assert.AreEqual(1.5 / 2, vector[1]);
            Assert.AreEqual(1.5 / 3, vector[2]);
        }

        [TestMethod]
        public void DivideVectorToVector()
        {
            DivideOperation op = new DivideOperation();
            Vector v = new Vector(new object[] { 1, 2, 3 });
            Vector v2 = new Vector(new object[] { 4, 5 });

            var result = op.Apply(v, v2);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(1 / 4.0, vector[0]);
            Assert.AreEqual(2 / 5.0, vector[1]);
            Assert.AreEqual(3 / 4.0, vector[2]);
        }
    }
}
