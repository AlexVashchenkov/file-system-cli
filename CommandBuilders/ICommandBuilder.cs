using FileSystemCli.Commands;

namespace FileSystemCli.CommandBuilders;

public interface ICommandBuilder
{
    public ICommand Build();
}