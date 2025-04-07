namespace FileSystemCli.ConnectionState;

public class Connected : IConnectionState
{
    public ConnectionOperationResult Connect(Context context)
    {
        return new ConnectionOperationResult.Failure("Already connected");
    }

    public ConnectionOperationResult Disconnect(Context context)
    {
        context.State = new NotConnected();
        return new ConnectionOperationResult.Success();
    }
}