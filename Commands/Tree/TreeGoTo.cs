using FileSystemCli.Models;
using FileSystemCli.Paths;

namespace FileSystemCli.Commands.Tree;

public class TreeGoTo : ICommand
{
    private readonly IPath _path;

    public TreeGoTo(IPath path)
    {
        _path = path;
    }

    public ExecutionResult Execute(Context context)
    {
        if (context.CurrentPath is null) return new ExecutionResult.Failure("Not connected");

        context.CurrentPath.ConstructPath(_path.Path);

        return new ExecutionResult.Success();
    }
}