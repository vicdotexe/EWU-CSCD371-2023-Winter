namespace Vehicles;

[TestClass]
public class BoatTests
{
    [TestMethod]
    public void Create_Boat_Success()
    {
        Boat boat = new(Guid.NewGuid(), 3);
        Assert.AreEqual<int>(3, boat.NumberOfSails);
    }

    [TestMethod]
    public void Create_2Boat_AreNotEqual()
    {
        Boat boat = new(Guid.NewGuid(), 3);
        Boat boat1 = new(Guid.NewGuid(), 3);
        Assert.AreNotEqual<Boat>(boat, boat1);
        
    }

    [TestMethod]
    public void Create_2DifferentBoats_AreEqual()
    {
        Guid guid = Guid.NewGuid();
        Boat boat = new(guid, 3);
        Boat boat1 = new(guid, 3);
        Assert.AreNotEqual<Boat>(boat, boat1);

    }
}
