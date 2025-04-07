using FileSystemCli.ConnectionState;
using FileSystemCli.FileSystem;
using FileSystemCli.Models;
using FileSystemCli.Paths;

namespace FileSystemCli.Commands.Connection;

public class Connect : ICommand
{
    private readonly IDirectory _localDirectory;
    private readonly AbsolutePath _path;

    public Connect(string path, IDirectory localDirectory)
    {
        _path = new AbsolutePath(path);
        _localDirectory = localDirectory;
    }

    public ExecutionResult Execute(Context context)
    {
        context.Directory = _localDirectory;
        if (_localDirectory.Exists(_path.Path))
        {
            if (context.Connect(_path, _localDirectory) is ConnectionOperationResult.Success)
                return new ExecutionResult.Success();

            context.Directory = null;
            return new ExecutionResult.Failure("Failed to connect");
        }

        context.Directory = null;
        return new ExecutionResult.Failure("Directory not found");
    }
}