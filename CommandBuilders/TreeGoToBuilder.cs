using System;
using FileSystemCli.CommandBuilders.Interfaces;
using FileSystemCli.Commands;
using FileSystemCli.Commands.Tree;
using FileSystemCli.Paths;

namespace FileSystemCli.CommandBuilders;

public class TreeGoToBuilder
    : ICommandBuilder, IWithPath<TreeGoToBuilder>
{
    private IPath? _path;

    public ICommand Build()
    {
        return new TreeGoTo(_path ?? throw new ArgumentNullException(nameof(_path)));
    }

    public TreeGoToBuilder WithPath(IPath path)
    {
        _path = path;
        return this;
    }
}