using System.Collections.Generic;
using FileSystemCli.CommandBuilders.Interfaces;
using FileSystemCli.Models;

namespace FileSystemCli.Parsers.Modes;

public class DepthParser<T> : ModeParserBase<T>
    where T : IWithDepth<T>
{
    private readonly ISingleModeParser<T>? _possibleModesParsingChain;

    public DepthParser(string flag, ISingleModeParser<T> possibleModesParsingChain)
    {
        Flag = flag;
        _possibleModesParsingChain = possibleModesParsingChain;
    }

    public override ModeParsingResult<T> ParseMode(T builder, IEnumerator<string> enumerator, Context context)
    {
        if (enumerator.Current == Flag)
        {
            if (!enumerator.MoveNext()) return new ModeParsingResult<T>.Failure("No mode was provided");

            if (_possibleModesParsingChain?.ParseSingleMode(builder, enumerator, context) is SingleModeParsingResult<T>
                    .Success)
                return new ModeParsingResult<T>.Success(builder);
        }

        enumerator.MoveNext();

        if (Successor is null)
        {
            if (!enumerator.MoveNext()) return new ModeParsingResult<T>.Success(builder);

            return new ModeParsingResult<T>.Failure("No viable argument for flag \'-d\' was provided");
        }

        return Successor.ParseMode(builder, enumerator, context);
    }
}