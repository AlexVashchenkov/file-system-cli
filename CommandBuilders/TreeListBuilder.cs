using FileSystemCli.CommandBuilders.Interfaces;
using FileSystemCli.Commands;
using FileSystemCli.Commands.Tree;

namespace FileSystemCli.CommandBuilders;

public class TreeListBuilder : ICommandBuilder, IWithDepth<TreeListBuilder>
{
    private int? _depth;

    public ICommand Build()
    {
        return new TreeList(_depth ?? 1);
    }

    public TreeListBuilder WithDepth(int? depth)
    {
        _depth = depth;
        return this;
    }
}