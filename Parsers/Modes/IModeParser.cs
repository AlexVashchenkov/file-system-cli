using System.Collections.Generic;
using FileSystemCli.Models;

namespace FileSystemCli.Parsers.Modes;

public interface IModeParser<T>
{
    public IModeParser<T> SetNextParser(IModeParser<T> modeParser);

    public ModeParsingResult<T> ParseMode(T builder, IEnumerator<string> enumerator, Context context);
}