using FileSystemCli.Models;
using FileSystemCli.Paths;

namespace FileSystemCli.Commands.File;

public class FileMove : ICommand
{
    private readonly IPath _destinationPath;
    private readonly IPath _sourcePath;

    public FileMove(IPath sourcePath, IPath destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public ExecutionResult Execute(Context context)
    {
        if (context.FirstConnectionPath is null ||
            context.Directory is null ||
            context.CurrentPath is null)
            return new ExecutionResult.Failure("Not connected");

        string executiveSourcePath = context.CurrentPath.ConstructPath(_sourcePath.Path).Path;
        string executiveDestinationPath = context.CurrentPath.ConstructPath(_destinationPath.Path).Path;

        return context.Directory.Move(executiveSourcePath, executiveDestinationPath);
    }
}