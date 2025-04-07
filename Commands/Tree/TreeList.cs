using FileSystemCli.Models;
using FileSystemCli.Printer;
using FileSystemCli.Visitors;

namespace FileSystemCli.Commands.Tree;

public class TreeList : ICommand
{
    private readonly int? _depth;

    public TreeList(int? depth)
    {
        _depth = depth;
    }

    public ExecutionResult Execute(Context context)
    {
        if (context.CurrentPath is null || context.Directory is null)
            return new ExecutionResult.Failure("Not connected");

        var visitor = new Visitor(new ConsolePrinter());

        context.Directory.GenerateTree(_depth).Accept(string.Empty, visitor);
        return new ExecutionResult.Success();
    }
}