namespace FileSystemCli.ConnectionState;

public interface IConnectionState
{
    public ConnectionOperationResult Connect(Context context);

    public ConnectionOperationResult Disconnect(Context context);
}