using System;
using System.Collections.Generic;
using FileSystemCli.CommandBuilders;
using FileSystemCli.Models;
using FileSystemCli.Parsers;

namespace FileSystemCli.Handlers.ConnectionHandler;

public class ConnectHandler : HandlerBase
{
    private readonly IParser<ConnectBuilder>? _parser;

    public ConnectHandler(string name, IParser<ConnectBuilder>? parser)
    {
        FunctionName = name;
        _parser = parser;
    }

    public override CommandParsingResult Handle(IEnumerator<string> enumerator, Context context)
    {
        if (enumerator.Current == FunctionName)
        {
            enumerator.MoveNext();

            var builder = new ConnectBuilder();

            if (_parser is not null)
            {
                var parsingResult = _parser.Parse(builder, enumerator, context);
                if (parsingResult is ArgumentsParsingResult<ConnectBuilder>.Failure failureResult)
                    return new CommandParsingResult.Failure(failureResult.Message);
            }

            try
            {
                builder.Build();
            }
            catch (ArgumentNullException)
            {
                return new CommandParsingResult.Failure("Not enough arguments provided");
            }

            return new CommandParsingResult.Success(builder.Build());
        }

        if (Successor is null)
            return new CommandParsingResult.Failure("No suitable command found - unable to parse");
        return Successor.Handle(enumerator, context);
    }
}