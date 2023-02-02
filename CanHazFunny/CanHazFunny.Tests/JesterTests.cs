using System;
using System.Data;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void Jester_TellsJoke()
        {
            string? result = null;

            var mockCommunicator = new Mock<ICommunicator>();
            mockCommunicator.Setup(x => x.Communicate(It.IsAny<string>())).Callback((string msg) =>
            {
                result = msg;
            });

            var jester = new Jester(new JokeService(), mockCommunicator.Object);
            jester.TellJoke();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ConsoleCommunicator_WritesToConsole()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var com = new ConsoleCommunicator();
            com.Communicate("test message");

            Assert.IsFalse(string.IsNullOrWhiteSpace(sw.ToString()));
        }

    }
    
}
