using System;
using FileSystemCli.CommandBuilders.Interfaces;
using FileSystemCli.Commands;
using FileSystemCli.Commands.File;
using FileSystemCli.Paths;

namespace FileSystemCli.CommandBuilders;

public class FileCopyBuilder : ICommandBuilder, IWithSourcePath<FileCopyBuilder>, IWithDestinationPath<FileCopyBuilder>
{
    private IPath? _destinationPath;
    private IPath? _sourcePath;

    public ICommand Build()
    {
        return new FileCopy(
            _sourcePath ?? throw new ArgumentNullException(nameof(_sourcePath)),
            _destinationPath ?? throw new ArgumentNullException(nameof(_destinationPath)));
    }

    public FileCopyBuilder WithDestinationPath(IPath path)
    {
        _destinationPath = path;
        return this;
    }

    public FileCopyBuilder WithSourcePath(IPath path)
    {
        _sourcePath = path;
        return this;
    }
}