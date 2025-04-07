using System.Collections.Generic;
using FileSystemCli.Models;

namespace FileSystemCli.Parsers.Modes;

public abstract class SingleModeParserBase<T> : ISingleModeParser<T>
{
    protected ISingleModeParser<T>? Successor { get; private set; }

    public ISingleModeParser<T> SetNextSingleParser(ISingleModeParser<T> modeParser)
    {
        if (Successor is null)
            Successor = modeParser;
        else
            Successor.SetNextSingleParser(modeParser);

        return this;
    }

    public abstract SingleModeParsingResult<T> ParseSingleMode(T builder, IEnumerator<string> enumerator,
        Context context);
}