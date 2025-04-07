using System;
using FileSystemCli.CommandBuilders.Interfaces;
using FileSystemCli.Commands;
using FileSystemCli.Commands.File;
using FileSystemCli.Paths;

namespace FileSystemCli.CommandBuilders;

public class FileMoveBuilder
    : ICommandBuilder, IWithSourcePath<FileMoveBuilder>, IWithDestinationPath<FileMoveBuilder>
{
    private IPath? _destinationPath;
    private IPath? _sourcePath;

    public ICommand Build()
    {
        return new FileMove(
            _sourcePath ?? throw new ArgumentNullException(nameof(_sourcePath)),
            _destinationPath ?? throw new ArgumentNullException(nameof(_destinationPath)));
    }

    public FileMoveBuilder WithDestinationPath(IPath path)
    {
        _destinationPath = path;
        return this;
    }

    public FileMoveBuilder WithSourcePath(IPath path)
    {
        _sourcePath = path;
        return this;
    }
}