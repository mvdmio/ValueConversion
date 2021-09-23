using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ridder.UnitsOfMeasurement.Enums.Quantities;
using System.Threading.Tasks;

namespace Ridder.UnitsOfMeasurement.Tests.Quantities.ElectricConductivity
{
    [TestClass]
    public class ElectricConductivityConversionTests
    {
        [TestMethod]
        public async Task ShouldConvertToStandardUnitCorrectly()
        {
            var milliSiemensPerCentimeter = Quantity.ElectricConductivity.GetUnit(Quantity.ElectricConductance.GetUnit(ElectricConductanceType.Millisiemens), Quantity.Distance.GetUnit(DistanceType.Centimeter));
            
            var value = Quantity.ElectricConductivity.CreateValue(5, milliSiemensPerCentimeter);
            var standardUnitValue = await value.GetStandardValue();

            Assert.AreEqual(0.5, standardUnitValue);
        }

         [TestMethod]
        public async Task ShouldConvertFromStandardUnitCorrectly()
        {
            var milliSiemensPerCentimeter = Quantity.ElectricConductivity.GetUnit(Quantity.ElectricConductance.GetUnit(ElectricConductanceType.Millisiemens), Quantity.Distance.GetUnit(DistanceType.Centimeter));
            
            var value = Quantity.ElectricConductivity.CreateValue(0.5, Quantity.ElectricConductivity.StandardUnit);
            var milliSiemensPerCentimeterValue = await value.As(milliSiemensPerCentimeter);

            Assert.AreEqual(5, milliSiemensPerCentimeterValue.GetValue());
        }
    }
}
