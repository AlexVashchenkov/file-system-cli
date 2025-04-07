using System.Collections.Generic;
using FileSystemCli.CommandBuilders;
using FileSystemCli.Handlers.ConnectionHandler;
using FileSystemCli.Handlers.FileHandlers;
using FileSystemCli.Handlers.TreeHandlers;
using FileSystemCli.Models;
using FileSystemCli.Parsers;
using FileSystemCli.Parsers.Arguments;
using FileSystemCli.Parsers.Modes;

namespace FileSystemCli.Handlers;

public class MasterHandler : HandlerBase
{
    public MasterHandler()
    {
        SetNext(new ConnectHandler("connect",
                new AbsolutePathParser<ConnectBuilder>().SetNextParser(new ModesParser<ConnectBuilder>(
                    new DirectoryModeParser<ConnectBuilder>("-m",
                        new DirectoryModeLocalParser<ConnectBuilder>("local")))))
            .SetNext(new DisconnectHandler("disconnect"))
            .SetNext(new TreeHandler("tree"))
            .SetNext(new FileHandler("file")));
    }

    public override CommandParsingResult Handle(IEnumerator<string> enumerator, Context context)
    {
        if (Successor != null) return Successor.Handle(enumerator, context);
        return new CommandParsingResult.Failure("No parsers were provided");
    }
}