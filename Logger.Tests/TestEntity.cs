using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class TestEntity
{
    [TestMethod]
    public void Book_CompareDifferentIds_NotEqual()
    {
        var title = "asdfads";
        var author = new FullName("fdas", "djas");

        var book = new Book(title, author);
        var book2 = new Book(title, author);

        Assert.AreNotEqual(book, book2);
    }

    [TestMethod]
    public void Book_CompareDifferentTitles_NotEqual()
    {
        var title = "asdfads";
        var author = new FullName("fdas", "djas");

        var book = new Book(title, author);
        var book2 = book with { Title = "New Title"};

        Assert.AreNotEqual(book, book2);
    }

    [TestMethod]
    public void Book_IEntityName_Equals_Title()
    {
        var title = "Hitchiker's Guide to the Galaxy";
        var author = new FullName("Douglass", "Adams");
        var book = new Book(title, author);
        Assert.AreEqual($"{title} - {author}", book.Name);
    }

    [TestMethod]
    public void Person_CompareDifferentNames_NotEqual()
    {
        var fullName = new FullName("Victor", "Korn");
        var fullName2 = new FullName("Cameron", "Miller");
        var person1 = new Person(fullName);
        var person2 = person1 with { FullName = fullName2 };
        Assert.AreNotEqual(person1, person2);
    }

    [TestMethod]
    public void Person_IEntityName_Equals_FullName()
    {
        var first = "Victor";
        var last = "Korn";
        var middle = "Ernest";
        var fullName = new FullName(first, last, middle);
        var person = new Person(fullName);
        Assert.AreEqual(person.Name, $"{first} {middle} {last}");
    }

    [TestMethod]
    public void StudentTest()
    {
        var fullName = new FullName("Victor", "Korn", "Ernest");
        var student = new Student(fullName, "CS");
        Assert.IsNotNull(student);
    }

}