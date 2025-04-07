using System.Collections.Generic;
using FileSystemCli.CommandBuilders.Interfaces;
using FileSystemCli.Models;
using FileSystemCli.Printer;

namespace FileSystemCli.Parsers.Modes;

public class OutputModeConsoleParser<T> : SingleModeParserBase<T>
    where T : IWithOutput<T>
{
    private readonly string _flagValue;

    public OutputModeConsoleParser(string flagValue)
    {
        _flagValue = flagValue;
    }

    public override SingleModeParsingResult<T> ParseSingleMode(T builder, IEnumerator<string> enumerator,
        Context context)
    {
        if (enumerator.Current == _flagValue)
        {
            builder.WithOutput(new ConsolePrinter());
            return new SingleModeParsingResult<T>.Success(builder);
        }

        if (Successor is null)
        {
            if (!enumerator.MoveNext()) return new SingleModeParsingResult<T>.Failure("Unknown mode provided");

            return new SingleModeParsingResult<T>.Failure("Flag argument parsing error: unable to parse");
        }

        return Successor.ParseSingleMode(builder, enumerator, context);
    }
}