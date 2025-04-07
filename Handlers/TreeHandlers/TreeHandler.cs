using System.Collections.Generic;
using FileSystemCli.CommandBuilders;
using FileSystemCli.Models;
using FileSystemCli.Parsers;
using FileSystemCli.Parsers.Arguments;
using FileSystemCli.Parsers.Modes;

namespace FileSystemCli.Handlers.TreeHandlers;

public class TreeHandler : HandlerBase
{
    private readonly IHandler _fileHandlers;

    public TreeHandler(string name)
    {
        FunctionName = name;
        _fileHandlers = new TreeListHandler("list",
                new ModesParser<TreeListBuilder>(
                    new DepthParser<TreeListBuilder>("-d", new DepthValueParser<TreeListBuilder>())))
            .SetNext(new TreeGoToHandler("goto", new PathParser<TreeGoToBuilder>()));
    }

    public override CommandParsingResult Handle(IEnumerator<string> enumerator, Context context)
    {
        if (enumerator.Current == FunctionName)
        {
            enumerator.MoveNext();
            return _fileHandlers.Handle(enumerator, context);
        }

        if (Successor is null) return new CommandParsingResult.Failure("No viable command was found");
        return Successor.Handle(enumerator, context);
    }
}