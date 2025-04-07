using System;
using FileSystemCli.CommandBuilders.Interfaces;
using FileSystemCli.Commands;
using FileSystemCli.Commands.Connection;
using FileSystemCli.FileSystem;

namespace FileSystemCli.CommandBuilders;

public class ConnectBuilder
    : ICommandBuilder, IWithAbsolutePath<ConnectBuilder>, IWithDirectory<ConnectBuilder>
{
    private IDirectoryFactory? _localDirectory;
    private string? _path;

    public ICommand Build()
    {
        return new Connect(
            _path ?? throw new ArgumentNullException(nameof(_path)),
            _localDirectory?.Create(_path) ?? throw new ArgumentNullException(nameof(_localDirectory)));
    }

    public ConnectBuilder WithAbsolutePath(string path)
    {
        _path = path;
        return this;
    }

    public ConnectBuilder WithDirectory(LocalDirectoryFactory directory)
    {
        _localDirectory = directory;
        return this;
    }
}