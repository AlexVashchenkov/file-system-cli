using System.Collections.Generic;
using FileSystemCli.Models;
using FileSystemCli.Parsers.Modes;

namespace FileSystemCli.Parsers;

public class ModesParser<T> : ParserBase<T>
{
    private readonly IModeParser<T>? _modeParserChain;

    public ModesParser(IModeParser<T>? modeParserChain)
    {
        _modeParserChain = modeParserChain;
    }

    public override ArgumentsParsingResult<T> Parse(T builder, IEnumerator<string> enumerator, Context context)
    {
        do
        {
            if (_modeParserChain?.ParseMode(builder, enumerator, context) is ModeParsingResult<T>.Failure failureResult)
                return new ArgumentsParsingResult<T>.Failure(failureResult.Message);
        } while (enumerator.MoveNext());

        return new ArgumentsParsingResult<T>.Success(builder);
    }
}