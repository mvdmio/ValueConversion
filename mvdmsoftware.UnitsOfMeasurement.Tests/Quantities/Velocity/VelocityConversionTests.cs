using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using System.Threading.Tasks;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Velocity
{
    [TestClass]
    public class VelocityConversionTests
    {
        [TestMethod]
        public async Task ShouldConvertCentimeterPerWeekToStandardUnitCorrectly()
        {
            var centimeterPerWeek = Quantity.Velocity.GetUnit(Quantity.Distance.GetUnit(DistanceType.Centimeter), Quantity.Duration.GetUnit(DurationType.Week));
            
            var value = Quantity.Velocity.CreateValue(12, centimeterPerWeek);
            var standardUnitValue = await value.GetStandardValue();

            Assert.AreEqual(1.9841269841269841E-07, standardUnitValue);
        }

        [TestMethod]
        public async Task ShouldConvertKilometerPerHourToStandardUnitCorrectly()
        {
            var kilometerPerHour = Quantity.Velocity.GetUnit(Quantity.Distance.GetUnit(DistanceType.Kilometer), Quantity.Duration.GetUnit(DurationType.Hour));
            
            var value = Quantity.Velocity.CreateValue(100, kilometerPerHour);
            var standardUnitValue = await value.GetStandardValue();

            Assert.AreEqual(27.77777777777778, standardUnitValue);
        }

        [TestMethod]
        public async Task ShouldConvertStandardUnitToKilometerPerHourCorrectly()
        {
            var standardUnit = Quantity.Velocity.StandardUnit;
            var kilometerPerHour = Quantity.Velocity.GetUnit(Quantity.Distance.GetUnit(DistanceType.Kilometer), Quantity.Duration.GetUnit(DurationType.Hour));
            
            var value = Quantity.Velocity.CreateValue(27.77777777777778, standardUnit);
            var kilometerPerHourValue = await value.As(kilometerPerHour);

            Assert.AreEqual(100, kilometerPerHourValue.GetValue());
        }
    }
}
