using System.Numerics;
using System.Text.RegularExpressions;

namespace Calculate;

public class Calculator
{
    private readonly Action<string>? _writeLine;
    public Action<string> WriteLine
    {
        get => _writeLine ?? throw new NullReferenceException(nameof(WriteLine)); 
        init => _writeLine = value ?? throw new ArgumentNullException(nameof(value));
    }

    private readonly Func<string?>? _readLine;
    public Func<string?> ReadLine
    {
        get => _readLine ?? throw new NullReferenceException(nameof(ReadLine));
        init => _readLine = value ?? throw new ArgumentNullException(nameof(value));
    }

    public IReadOnlyDictionary<char, Func<double, double, double>> MathematicalOperations { get; } =
        new Dictionary<char, Func<double, double, double>>()
        {
            { '+', Add },
            { '-', Subtract },
            { '*', Multiply },
            { '/', Divide }
        };
    

    public Calculator() : this(Console.WriteLine, Console.ReadLine)
    {

    }

    public Calculator(Action<string> writeLine, Func<string?> readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;
    }

    public bool TryCalculate(string? expression, out string? result)
    {
        result = null;

        if (expression?.Split(" ") is [string a, [char o], string b])
        {
            if (int.TryParse(a, out int aInt)
                && int.TryParse(b, out int bInt)
                && MathematicalOperations.TryGetValue(o, out var func))
            {
                result = func(aInt, bInt).ToString();
                WriteLine(result);
                return true;
            }
        }

        WriteLine("Invalid Format");
        return false;
    }

    public static double Add(double a, double b) => a + b;
    public static double Subtract(double a, double b) => a - b;
    public static double Multiply(double a, double b) => a * b;
    public static double Divide(double a, double b) => a / b;

}