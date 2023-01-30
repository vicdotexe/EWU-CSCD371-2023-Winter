using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests : FileLoggerTestsBase
{
    [ClassInitialize]
    public void TestSetup(TestContext testContext)
    {
    }
    // FileLogger? Logger { get; set; }

    [TestInitialize]
    public void CreateLogger()
    {
        TestCleanup();
        Logger = new(nameof(FileLoggerTests), "myfile.txt");
    }

    [TestCleanup]
    public override void TestCleanup()
    {
        base.TestCleanup();
        // Do something here
    }



    [TestMethod]
    public void Create_Success()
    {
        Assert.IsNotNull(Logger);
    }

    [TestMethod]
    public void Create_Success1()
    {
         Logger?.Log(LogLevel.Warning, "Hi@! My name is ...");
    }
    
    //[TestMethod]
    //public void Create_GivenClassAndValidFileName_Success()b
    //{
    //    Assert.AreEqual(nameof(FileLoggerTests), Logger.LogSource);
    //    Assert.AreEqual(FilePath, Logger.FilePath);
    //}

    //[TestMethod]
    //public async Task Log_Message_FileAppended()
    //{
    //    Logger.Log(LogLevel.Error, "Message1");
    //    Logger.Log(LogLevel.Error, "Message2");

    //    string[] lines = await File.ReadAllLinesAsync(FilePath);
    //    Assert.IsTrue(lines is [..] and { Length: 2 });
    //    foreach (string[] line in lines.Select(line => line.Split(',', 4)))
    //    {
    //        if (line is [string dateTime, string source, string levelText, string message])
    //        {
    //            Assert.IsTrue(DateTime.TryParse(dateTime, out _));
    //            Assert.AreEqual(nameof(FileLoggerTests), source);
    //            Assert.IsTrue(Enum.TryParse(typeof(LogLevel), levelText, out object? level) ?
    //                level is LogLevel.Error : false,"Level was not parsed successfully.");
    //        }
    //    }
    //}
}
