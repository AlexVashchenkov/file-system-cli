namespace FileSystemCli.Models;

public abstract record ArgumentsParsingResult<T>
{
    private ArgumentsParsingResult()
    {
    }

    public sealed record Success(T Builder) : ArgumentsParsingResult<T>;

    public sealed record Failure(string Message) : ArgumentsParsingResult<T>;
}