using System.Collections.Generic;
using FileSystemCli.Models;

namespace FileSystemCli.Parsers.Modes;

public interface ISingleModeParser<T>
{
    public ISingleModeParser<T> SetNextSingleParser(ISingleModeParser<T> modeParser);

    public SingleModeParsingResult<T> ParseSingleMode(T builder, IEnumerator<string> enumerator, Context context);
}