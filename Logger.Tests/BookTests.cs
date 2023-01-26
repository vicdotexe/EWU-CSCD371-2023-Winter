using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;


[TestClass]
public class BookTests
{
    [TestMethod]
    public void Create_Book_Success()
    {
        Book book = new ("The Purple Crayon", "", "");

        Assert.AreEqual("The Purple Crayon", book.Title);
    }

    [TestMethod]
    public void Create_ILogger_Success()
    {
        Book book = new("Princess Bride", "", "");
        string bookContent = book.ToString();

        Assert.AreEqual("Princess Bride", bookContent);
    }
}
