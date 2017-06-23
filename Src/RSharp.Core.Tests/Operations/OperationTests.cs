namespace RSharp.Core.Tests.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Language;
    using RSharp.Core.Operations;

    [TestClass]
    public class OperationTests
    {
        [TestMethod]
        public void AddNumbers()
        {
            AddOperation op = AddOperation.Instance;

            Assert.AreEqual(1 + 2, op.Apply(1, 2));
            Assert.AreEqual(1.2 + 3.4, op.Apply(1.2, 3.4));
            Assert.AreEqual(1 + 2.3, op.Apply(1, 2.3));
            Assert.AreEqual(1.2 + 3, op.Apply(1.2, 3));
        }

        [TestMethod]
        public void AddVectorToInteger()
        {
            AddOperation op = AddOperation.Instance;

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
            AddOperation op = AddOperation.Instance;

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
            AddOperation op = AddOperation.Instance;

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
            AddOperation op = AddOperation.Instance;

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
            AddOperation op = AddOperation.Instance;
            
            Vector v = new Vector(new object[] { 1, 2, 3 });
            Vector v2 = new Vector(new object[] { 4, 5 });

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
            SubtractOperation op = SubtractOperation.Instance;

            Assert.AreEqual(1 - 2, op.Apply(1, 2));
            Assert.AreEqual(1.2 - 3.4, op.Apply(1.2, 3.4));
            Assert.AreEqual(1 - 2.3, op.Apply(1, 2.3));
            Assert.AreEqual(1.2 - 3, op.Apply(1.2, 3));
        }

        [TestMethod]
        public void SubtractIntegerFromVector()
        {
            SubtractOperation op = SubtractOperation.Instance;
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
            SubtractOperation op = SubtractOperation.Instance;
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
            SubtractOperation op = SubtractOperation.Instance;
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
            MultiplyOperation op = MultiplyOperation.Instance;

            Assert.AreEqual(3 * 2, op.Apply(3, 2));
            Assert.AreEqual(1.2 * 3.4, op.Apply(1.2, 3.4));
            Assert.AreEqual(4 * 2.3, op.Apply(4, 2.3));
            Assert.AreEqual(1.2 * 3, op.Apply(1.2, 3));
        }

        [TestMethod]
        public void MultiplyVectorToInteger()
        {
            MultiplyOperation op = MultiplyOperation.Instance;
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
            MultiplyOperation op = MultiplyOperation.Instance;
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
            MultiplyOperation op = MultiplyOperation.Instance;
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
            MultiplyOperation op = MultiplyOperation.Instance;
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
            MultiplyOperation op = MultiplyOperation.Instance;
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
            DivideOperation op = DivideOperation.Instance;

            Assert.AreEqual(1 / 2.0, op.Apply(1, 2));
            Assert.AreEqual(2, op.Apply(4, 2));
            Assert.AreEqual(1.2 / 3.4, op.Apply(1.2, 3.4));
            Assert.AreEqual(1 / 2.3, op.Apply(1, 2.3));
            Assert.AreEqual(1.2 / 3, op.Apply(1.2, 3));
        }

        [TestMethod]
        public void DivideVectorByInteger()
        {
            DivideOperation op = DivideOperation.Instance;

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
            DivideOperation op = DivideOperation.Instance;

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
            DivideOperation op = DivideOperation.Instance;

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
            DivideOperation op = DivideOperation.Instance;

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
            DivideOperation op = DivideOperation.Instance;

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

        [TestMethod]
        public void ModulusIntegers()
        {
            ModulusOperation op = ModulusOperation.Instance;

            Assert.AreEqual(1, op.Apply(3, 2));
            Assert.AreEqual(0, op.Apply(4, 2));
        }

        [TestMethod]
        public void EqualIntegers()
        {
            EqualOperation op = EqualOperation.Instance;

            Assert.AreEqual(false, op.Apply(3, 2));
            Assert.AreEqual(true, op.Apply(2, 2));
        }

        [TestMethod]
        public void SequenceCreateVector()
        {
            SequenceOperation op = SequenceOperation.Instance;

            var result = op.Apply(1, 20);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(20, vector.Length);

            for (int k = 0; k < 20; k++)
                Assert.AreEqual(k + 1, vector[k]);
        }
    }
}
