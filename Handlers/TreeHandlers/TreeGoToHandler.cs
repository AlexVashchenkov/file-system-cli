using System;
using System.Collections.Generic;
using FileSystemCli.CommandBuilders;
using FileSystemCli.Models;
using FileSystemCli.Parsers;

namespace FileSystemCli.Handlers.TreeHandlers;

public class TreeGoToHandler : HandlerBase
{
    private readonly IParser<TreeGoToBuilder> _parser;

    public TreeGoToHandler(string name, IParser<TreeGoToBuilder> parser)
    {
        FunctionName = name;
        _parser = parser;
    }

    public override CommandParsingResult Handle(IEnumerator<string> enumerator, Context context)
    {
        if (enumerator.Current == FunctionName)
        {
            enumerator.MoveNext();

            var builder = new TreeGoToBuilder();
            var parsingResult = _parser.Parse(builder, enumerator, context);
            if (parsingResult is ArgumentsParsingResult<TreeGoToBuilder>.Failure failureResult)
                return new CommandParsingResult.Failure(failureResult.Message);

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