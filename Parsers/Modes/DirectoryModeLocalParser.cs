using System.Collections.Generic;
using FileSystemCli.CommandBuilders.Interfaces;
using FileSystemCli.FileSystem;
using FileSystemCli.Models;

namespace FileSystemCli.Parsers.Modes;

public class DirectoryModeLocalParser<T> : SingleModeParserBase<T>
    where T : IWithDirectory<T>
{
    private readonly string _flagValue;

    public DirectoryModeLocalParser(string flagValue)
    {
        _flagValue = flagValue;
    }

    public override SingleModeParsingResult<T> ParseSingleMode(T builder, IEnumerator<string> enumerator,
        Context context)
    {
        if (enumerator.Current == _flagValue) builder.WithDirectory(new LocalDirectoryFactory());

        if (Successor is null)
        {
            if (!enumerator.MoveNext()) return new SingleModeParsingResult<T>.Failure("Unknown mode provided");

            return new SingleModeParsingResult<T>.Failure("Flag argument parsing error: unable to parse");
        }

        return Successor.ParseSingleMode(builder, enumerator, context);
    }
}