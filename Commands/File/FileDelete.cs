using FileSystemCli.Models;
using FileSystemCli.Paths;

namespace FileSystemCli.Commands.File;

public class FileDelete : ICommand
{
    private readonly IPath _path;

    public FileDelete(IPath path)
    {
        _path = path;
    }

    public ExecutionResult Execute(Context context)
    {
        if (context.FirstConnectionPath is null ||
            context.Directory is null ||
            context.CurrentPath is null)
            return new ExecutionResult.Failure("Not connected");

        string executivePath = context.CurrentPath.ConstructPath(_path.Path).Path;

        return context.Directory.Delete(executivePath);
    }
}