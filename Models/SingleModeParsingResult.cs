namespace FileSystemCli.Models;

public record SingleModeParsingResult<T>
{
    private SingleModeParsingResult()
    {
    }

    public sealed record Success(T Builder) : SingleModeParsingResult<T>;

    public sealed record Failure(string Message) : SingleModeParsingResult<T>;
}