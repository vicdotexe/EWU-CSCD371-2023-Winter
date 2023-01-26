using System;
using System.Diagnostics.CodeAnalysis;

namespace Logger;

public class LogFactory
{
    private string? _Name;

    public string Name { get => _Name!; set => _Name = value ?? throw new ArgumentNullException(nameof(value)); }
    
    public LogFactory(string name)
    {
        Name = name;
    }

    

    public ILogger CreateLogger(string className)
    {
        return null;
    }
}
