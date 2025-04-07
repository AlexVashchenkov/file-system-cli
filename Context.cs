using FileSystemCli.ConnectionState;
using FileSystemCli.FileSystem;
using FileSystemCli.Paths;

namespace FileSystemCli;

public class Context
{
    public AbsolutePath? FirstConnectionPath { get; private set; }

    public AbsolutePath? CurrentPath { get; internal set; }

    public IDirectory? Directory { get; internal set; }

    public IConnectionState State { get; internal set; } = new NotConnected();

    public ConnectionOperationResult Connect(AbsolutePath path, IDirectory directory)
    {
        if (State is NotConnected)
        {
            FirstConnectionPath = path;
            CurrentPath = FirstConnectionPath;
            Directory = directory;
        }

        return State.Connect(this);
    }

    public ConnectionOperationResult Disconnect()
    {
        if (State is Connected)
        {
            FirstConnectionPath = null;
            CurrentPath = null;
            Directory = null;
        }

        return State.Disconnect(this);
    }
}