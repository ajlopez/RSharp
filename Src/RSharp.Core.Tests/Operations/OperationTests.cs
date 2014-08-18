namespace RSharp.Core.Tests.Operations
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Operations;

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
