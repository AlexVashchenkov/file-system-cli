namespace FileSystemCli.Models;

public abstract record ExecutionResult
{
    private ExecutionResult()
    {
    }

    public sealed record Success : ExecutionResult;

    public sealed record Failure(string Message) : ExecutionResult;
}