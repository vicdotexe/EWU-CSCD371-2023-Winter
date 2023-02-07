using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class TestStorage
{
    private readonly Storage _storage = new ();

    [TestMethod]
    public void Storage_GetValidId_ReturnsValidEntity()
    {
        var author = new FullName("Douglass", "Adams");
        var book = new Book("Hitchiker's Guide to the Galaxy", author);
        _storage.Add(book);
        
        Assert.AreEqual(book, _storage.Get(book.Id));
    }

    [TestMethod]
    public void Storage_GetInvalidId_ReturnsNull()
    {
        Assert.IsNull(_storage.Get(Guid.NewGuid()));
    }

    [TestMethod]
    public void Storage_AddRemoveEntity()
    {
        var fullName = new FullName("Victor", "Korn");
        var employee = new Employee(fullName, "Cook");
        _storage.Add(employee);
        Assert.IsTrue(_storage.Contains(employee));
        _storage.Remove(employee);
        Assert.IsFalse(_storage.Contains(employee));
    }

    [TestMethod]
    public void Storage_ContainsEntity()
    {
        var fullName = new FullName("Victor", "Korn");
        var person = new Person(fullName);
        _storage.Add(person);
        Assert.IsTrue(_storage.Contains(person));
    }


}