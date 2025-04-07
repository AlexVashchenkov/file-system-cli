namespace FileSystemCli.ConnectionState;

public abstract record ConnectionOperationResult
{
    private ConnectionOperationResult()
    {
    }

    public sealed record Success : ConnectionOperationResult;

    public sealed record Failure(string Message) : ConnectionOperationResult;
}