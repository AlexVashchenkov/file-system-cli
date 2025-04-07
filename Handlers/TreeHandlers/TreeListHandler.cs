using System;
using System.Collections.Generic;
using FileSystemCli.CommandBuilders;
using FileSystemCli.Models;
using FileSystemCli.Parsers;

namespace FileSystemCli.Handlers.TreeHandlers;

public class TreeListHandler : HandlerBase
{
    private readonly IParser<TreeListBuilder>? _parser;

    public TreeListHandler(string name, IParser<TreeListBuilder>? parser = null)
    {
        FunctionName = name;
        _parser = parser;
    }

    public override CommandParsingResult Handle(IEnumerator<string> enumerator, Context context)
    {
        if (enumerator.Current == FunctionName)
        {
            enumerator.MoveNext();

            var builder = new TreeListBuilder();
            if (_parser is not null)
            {
                var parsingResult = _parser.Parse(builder, enumerator, context);
                if (parsingResult is ArgumentsParsingResult<TreeListBuilder>.Failure failureResult)
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
            return new CommandParsingResult.Failure("No suitable \'tree\' command was found - unable to parse");

        return Successor.Handle(enumerator, context);
    }
}