using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class MyTestClass
{
    [TestMethod]
    public void MyTestMethod()
    {
        TestConsole testConsole = new();

        testConsole.MaxMessageLength = 42;

        Assert.AreEqual(42, testConsole.MaxMessageLength);
    }

    [TestMethod]
    public void Log_ExplicitlyImplemented()
    {
        TestConsole console = new();
        ((ILogger)console).Log(LogLevel.Error, "Message");
    }

    [TestMethod]
    public void CreateLogger_CreatesLogger_WithMaxLength42()
    {
        ILogger testConsole = TestConsole.CreateLogger();
        Assert.AreEqual(42, testConsole.MaxMessageLength);
    }
}


public class TestConsole : ILogger
{
    public int MaxMessageLength { get; set; }

    public static ILogger CreateLogger()
    {
        TestConsole testConsole = new();
        testConsole.MaxMessageLength = 42;

        return testConsole;
    }

    void ILogger.Log(LogLevel logLevel, string message)
    {
        Console.WriteLine($"[{logLevel}]: {message}");;
    }
}

