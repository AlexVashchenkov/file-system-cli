using FileSystemCli.ConnectionState;
using FileSystemCli.Models;

namespace FileSystemCli.Commands.Connection;

public class Disconnect : ICommand
{
    public ExecutionResult Execute(Context context)
    {
        if (context.Disconnect() is ConnectionOperationResult.Failure)
            return new ExecutionResult.Failure("Already disconnected");

        return new ExecutionResult.Success();
    }
}