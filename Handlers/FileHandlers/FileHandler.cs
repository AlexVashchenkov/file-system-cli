using System.Collections.Generic;
using FileSystemCli.CommandBuilders;
using FileSystemCli.Models;
using FileSystemCli.Parsers;
using FileSystemCli.Parsers.Arguments;
using FileSystemCli.Parsers.Modes;

namespace FileSystemCli.Handlers.FileHandlers;

public class FileHandler : HandlerBase
{
    private readonly IHandler _fileHandlers;

    public FileHandler(string name)
    {
        FunctionName = name;
        _fileHandlers = new FileCopyHandler("copy",
                new SourcePathParser<FileCopyBuilder>().SetNextParser(new DestinationPathParser<FileCopyBuilder>()))
            .SetNext(new FileMoveHandler("move",
                    new SourcePathParser<FileMoveBuilder>().SetNextParser(new DestinationPathParser<FileMoveBuilder>()))
                .SetNext(new FileShowHandler("show",
                    new PathParser<FileShowBuilder>().SetNextParser(new ModesParser<FileShowBuilder>(
                        new OutputModeParser<FileShowBuilder>("-m",
                            new OutputModeConsoleParser<FileShowBuilder>("console")))))))
            .SetNext(new FileDeleteHandler("delete", new PathParser<FileDeleteBuilder>()))
            .SetNext(new FileRenameHandler("rename",
                new PathParser<FileRenameBuilder>().SetNextParser(new NameParser<FileRenameBuilder>())));
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