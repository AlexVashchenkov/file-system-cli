namespace FileSystemCli.Models;

public abstract record ModeParsingResult<T>
{
    private ModeParsingResult()
    {
    }

    public sealed record Success(T Builder) : ModeParsingResult<T>;

    public sealed record Failure(string Message) : ModeParsingResult<T>;
}