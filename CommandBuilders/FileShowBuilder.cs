using System;
using FileSystemCli.CommandBuilders.Interfaces;
using FileSystemCli.Commands;
using FileSystemCli.Commands.File;
using FileSystemCli.Paths;
using FileSystemCli.Printer;

namespace FileSystemCli.CommandBuilders;

public class FileShowBuilder : IWithPath<FileShowBuilder>, IWithOutput<FileShowBuilder>, ICommandBuilder
{
    private IPath? _path;
    private IPrinter? _printer;

    public ICommand Build()
    {
        return new FileShow(
            _path ?? throw new ArgumentNullException(nameof(_path)),
            _printer);
    }

    public FileShowBuilder WithOutput(IPrinter printer)
    {
        _printer = printer;
        return this;
    }

    public FileShowBuilder WithPath(IPath path)
    {
        _path = path;
        return this;
    }
}