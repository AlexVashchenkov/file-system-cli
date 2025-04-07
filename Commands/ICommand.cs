using FileSystemCli.Models;
namespace FileSystemCli.Commands;

public interface ICommand
{
    public ExecutionResult Execute(Context context);
}