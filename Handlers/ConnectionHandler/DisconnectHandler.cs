using System.Collections.Generic;
using FileSystemCli.Commands.Connection;
using FileSystemCli.Models;
using FileSystemCli.Parsers;

namespace FileSystemCli.Handlers.ConnectionHandler;

public class DisconnectHandler : HandlerBase
{
    private IParser<DisconnectHandler>? _parser;

    public DisconnectHandler(string name, IParser<DisconnectHandler>? parser = null)
    {
        FunctionName = name;
        _parser = parser;
    }

    public override CommandParsingResult Handle(IEnumerator<string> enumerator, Context context)
    {
        if (enumerator.Current == FunctionName)
        {
            if (!enumerator.MoveNext()) return new CommandParsingResult.Success(new Disconnect());

            return new CommandParsingResult.Failure("Too many arguments provided");
        }

        if (Successor is null)
            return new CommandParsingResult.Failure("No suitable \'disconnect\' command was found - unable to parse");
        return Successor.Handle(enumerator, context);
    }
}