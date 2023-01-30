namespace Vehicles;

[TestClass]
public class VehicleTests
{
    [TestMethod]
    public void TestMethod1()
    {
        Amphibious amphibious = new();
        ICar car = amphibious;
        car.Reverse();
        ((ICar)amphibious).Reverse();
    }
}