namespace RSharp.Core.Tests.Functions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RSharp.Core.Functions;
    using RSharp.Core.Language;

    [TestClass]
    public class MakeVectorTests
    {
        [TestMethod]
        public void MakeVectorWithThreeIntegers()
        {
            MakeVector fn = new MakeVector();

            var result = fn.Apply(null, new object[] { 1, 2, 3 }, null);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Vector));

            var vector = (Vector)result;

            Assert.AreEqual(3, vector.Length);
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(2, vector[1]);
            Assert.AreEqual(3, vector[2]);
        }
    }
}
