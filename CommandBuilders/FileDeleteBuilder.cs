using System;
using FileSystemCli.CommandBuilders.Interfaces;
using FileSystemCli.Commands;
using FileSystemCli.Commands.File;
using FileSystemCli.Paths;

namespace FileSystemCli.CommandBuilders;

public class FileDeleteBuilder : ICommandBuilder, IWithPath<FileDeleteBuilder>
{
    private IPath? _path;

    public ICommand Build()
    {
        return new FileDelete(_path ?? throw new ArgumentNullException(nameof(_path)));
    }

    public FileDeleteBuilder WithPath(IPath path)
    {
        _path = path;
        return this;
    }
}