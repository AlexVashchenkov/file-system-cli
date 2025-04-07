using FileSystemCli.Commands;
using FileSystemCli.Commands.Connection;

namespace FileSystemCli.CommandBuilders;

public class DisconnectBuilder : ICommandBuilder
{
    public ICommand Build()
    {
        return new Disconnect();
    }
}