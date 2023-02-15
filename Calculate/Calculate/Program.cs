// See https://aka.ms/new-console-template for more information

using Calculate;

Console.WriteLine("Welcome to the calculator.");

var calc = new Calculator();

while (true)
{
    var input = calc.ReadLine();
    if (input == "exit")
        break;
    calc.Calculate(input);
}