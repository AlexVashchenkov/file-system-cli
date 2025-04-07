namespace FileSystemCli.ConnectionState;

public class NotConnected : IConnectionState
{
    public ConnectionOperationResult Connect(Context context)
    {
        context.State = new Connected();
        return new ConnectionOperationResult.Success();
    }

    public ConnectionOperationResult Disconnect(Context context)
    {
        return new ConnectionOperationResult.Failure("Already disconnected");
    }
}