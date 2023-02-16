namespace Calculate.Tests
{
    [TestClass]
    public class CalculateTest
    {
        [TestMethod]
        public void WriteLine()
        {
            var output = "";
            var calc = new Calculator((text)=>output=text , Console.ReadLine);

            calc.WriteLine.Invoke("test");
            Assert.AreEqual("test", output);
        }

        [TestMethod]
        public void ReadLine()
        {
            
            var calc = new Calculator(Console.WriteLine, () => "test");
            Assert.AreEqual("test", calc.ReadLine());
        }

        [TestMethod]
        public void DefaultConstructor()
        {
            _ = new Calculator();
        }

        [TestMethod]
        public void Calculate_InvalidFormat_WritesError()
        {
            var output = "";

            var calc = new Calculator((text)=>output=text, Console.ReadLine);

            calc.Calculate("");
            Assert.AreEqual(output, "Invalid Format");
            calc.Calculate("1 +");
            Assert.AreEqual(output, "Invalid Format");
            calc.Calculate(" + 1");
            Assert.AreEqual(output, "Invalid Format");
            calc.Calculate("a+b");
            Assert.AreEqual(output, "Invalid Format");
            calc.Calculate("a+ b");
            Assert.AreEqual(output, "Invalid Format");
            calc.Calculate("a +b");
            Assert.AreEqual(output, "Invalid Format");
            calc.Calculate("a + b");
            Assert.AreEqual(output, "Invalid Format");
        }

        [TestMethod]
        public void Calculate_ValidFormat_Succeeds()
        {
            var output = "";

            var calc = new Calculator((text)=>output=text, Console.ReadLine);

            calc.Calculate("1 + 2");
            Assert.AreNotEqual(output, "Invalid Format");
            calc.Calculate("1 * 2");
            Assert.AreNotEqual(output, "Invalid Format");
            calc.Calculate("1 / 2");
            Assert.AreNotEqual(output, "Invalid Format");
            calc.Calculate("1 - 2");
            Assert.AreNotEqual(output, "Invalid Format");
            calc.Calculate("-1 * -2");
            Assert.AreNotEqual(output, "Invalid Format");
            calc.Calculate("-1 * 2");
            Assert.AreNotEqual(output, "Invalid Format");
            calc.Calculate("1 * -2");
            Assert.AreNotEqual(output, "Invalid Format");
            calc.Calculate("-1.15 * 2");
            Assert.AreNotEqual(output, "Invalid Format");
            calc.Calculate("1.15 * -2.15");
            Assert.AreNotEqual(output, "Invalid Format");
        }

        [TestMethod]
        public void Calculate_PerformsValidMaths()
        {
            var output = "";

            var calc = new Calculator((text) => output = text, Console.ReadLine);

            calc.Calculate("1 + 2");
            Assert.AreEqual(output, "3");
            calc.Calculate("2 * 2");
            Assert.AreEqual(output, "4");
            calc.Calculate("5 - 2");
            Assert.AreEqual(output, "3");
            calc.Calculate("10 / 5");
            Assert.AreEqual(output, "2");
            calc.Calculate("-1 + 5");
            Assert.AreEqual(output, "4");
            calc.Calculate("-1 * 5");
            Assert.AreEqual(output, "-5");
            calc.Calculate("1 / -2");
            Assert.AreEqual(output, "-0.5");
            calc.Calculate("1 - -2");
            Assert.AreEqual(output, "3");
        }

    }
}