using System;
using FileSystemCli.CommandBuilders.Interfaces;
using FileSystemCli.Commands;
using FileSystemCli.Commands.File;
using FileSystemCli.Paths;

namespace FileSystemCli.CommandBuilders;

public class FileRenameBuilder : ICommandBuilder, IWithPath<FileRenameBuilder>, IWithNewName<FileRenameBuilder>
{
    private string? _name;
    private IPath? _path;

    public ICommand Build()
    {
        return new FileRename(
            _path ?? throw new ArgumentNullException(nameof(_path)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }

    public FileRenameBuilder WithNewName(string name)
    {
        _name = name;
        return this;
    }

    public FileRenameBuilder WithPath(IPath path)
    {
        _path = path;
        return this;
    }
}