using System.Collections.Generic;
using FileSystemCli.Models;

namespace FileSystemCli.Parsers.Modes;

public abstract class ModeParserBase<T> : IModeParser<T>
{
    public string Flag { get; protected init; } = string.Empty;

    protected IModeParser<T>? Successor { get; private set; }

    public IModeParser<T> SetNextParser(IModeParser<T> modeParser)
    {
        if (Successor is null)
            Successor = modeParser;
        else
            Successor.SetNextParser(modeParser);

        return this;
    }

    public abstract ModeParsingResult<T> ParseMode(T builder, IEnumerator<string> enumerator, Context context);
}