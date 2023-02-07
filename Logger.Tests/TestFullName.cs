using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

public class TestFullName
{
    [TestMethod]
    public void FullName_IsNotNull()
    {
        Assert.IsNotNull(new FullName("Victor", "Korn", "Ernest"));
    }

    [TestMethod]
    public void FullName_ExcludingMiddle_IsNotNull()
    {
        Assert.IsNotNull(new FullName("Victor", "Korn"));
    }

    [TestMethod]
    public void FullName_CompareIdenticalValues_AreEqual()
    {
        var fullname1 = new FullName("Victor", "Korn", "Ernest");
        var fullname2 = new FullName("Victor", "Korn", "Ernest");
        Assert.AreEqual(fullname1,fullname2);
    }

    [TestMethod]
    public void FullName_CompareDifferentValues_AreNotEqual()
    {
        var fullname1 = new FullName("Victor", "Korn", "Ernest");
        var fullname2 = new FullName("Vic", "Korn", "E");
        Assert.AreNotEqual(fullname1, fullname2);
    }
}