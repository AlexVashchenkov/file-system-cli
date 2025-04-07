using FileSystemCli.Models;
using FileSystemCli.Paths;
using FileSystemCli.Printer;

namespace FileSystemCli.Commands.File;

public class FileShow : ICommand
{
    private readonly IPath _path;
    private readonly IPrinter _printer;

    public FileShow(IPath path, IPrinter? printer)
    {
        _path = path;
        _printer = printer ?? new ConsolePrinter();
    }

    public ExecutionResult Execute(Context context)
    {
        if (context.FirstConnectionPath is null ||
            context.Directory is null ||
            context.CurrentPath is null)
            return new ExecutionResult.Failure("Not connected");

        string executivePath = context.CurrentPath.ConstructPath(_path.Path).Path;

        return context.Directory.Show(executivePath, _printer);
    }
}