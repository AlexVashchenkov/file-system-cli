using FileSystemCli.Models;
using FileSystemCli.Paths;

namespace FileSystemCli.Commands.File;

public class FileRename : ICommand
{
    private readonly string _name;
    private readonly IPath _path;

    public FileRename(IPath path, string name)
    {
        _path = path;
        _name = name;
    }

    public ExecutionResult Execute(Context context)
    {
        if (context.FirstConnectionPath is null ||
            context.Directory is null ||
            context.CurrentPath is null)
            return new ExecutionResult.Failure("Not connected");

        string executivePath = context.CurrentPath.ConstructPath(_path.Path).Path;

        return context.Directory.Rename(executivePath, _name);
    }
}