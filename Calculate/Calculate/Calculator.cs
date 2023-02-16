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

    private static readonly Regex ValidMathExpression = new(@"^[-]?\d+([.]\d+)?(\s[+/*-]\s)[-]?\d+([.]\d+)?$");

    public Calculator() : this(Console.WriteLine, Console.ReadLine)
    {

    }

    public Calculator(Action<string> writeLine, Func<string?> readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;
    }

    public void Calculate(string? expression)
    {
        if (expression is null || !ValidMathExpression.IsMatch(expression))
        {
            WriteLine.Invoke("Invalid Format");
            return;
        }

        var split = expression.Split(" ");
        var a = double.Parse(split[0]);
        var b = double.Parse(split[2]);
        var o = char.Parse(split[1]);

        var result = MathematicalOperations[o].Invoke(a, b);
        WriteLine.Invoke(result.ToString());
    }

    public static double Add(double a, double b)
    {
        return a + b;
    }
    public static double Subtract(double a, double b)
    {
        return a - b;
    }
    public static double Multiply(double a, double b)
    {
        return a * b;
    }
    public static double Divide(double a, double b)
    {
        return a / b;
    }

}