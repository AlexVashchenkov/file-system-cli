using FileSystemCli.Commands;

namespace FileSystemCli.Models;

public abstract record CommandParsingResult
{
    private CommandParsingResult()
    {
    }

    public sealed record Success(ICommand Command) : CommandParsingResult;

    public sealed record Failure(string Message) : CommandParsingResult;
}