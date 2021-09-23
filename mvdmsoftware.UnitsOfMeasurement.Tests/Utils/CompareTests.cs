using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ridder.Common;

namespace Ridder.UnitsOfMeasurement.Tests.Utils
{
    [TestClass]
    public class CompareTests
    {
        [TestMethod]
        public void ZerosShouldBeEqual()
        {
            Assert.IsTrue(Compare.IsRelativeEqual(0, 0));
        }

        [TestMethod]
        public void OnesShouldBeEqual()
        {
            Assert.IsTrue(Compare.IsRelativeEqual(1, 1));
        }
    }
}
