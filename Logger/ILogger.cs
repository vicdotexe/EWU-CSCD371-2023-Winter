namespace Logger;

public interface ILogger
{
    int MaxMessageLength { get; set; }
    
    void Log(LogLevel logLevel, string message);

    void Write(LogLevel logLevel, string message)
    {
        Log(logLevel, message);
    }

    static abstract ILogger CreateLogger();
}