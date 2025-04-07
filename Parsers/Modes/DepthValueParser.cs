using System.Collections.Generic;
using FileSystemCli.CommandBuilders.Interfaces;
using FileSystemCli.Models;

namespace FileSystemCli.Parsers.Modes;

public class DepthValueParser<T> : SingleModeParserBase<T>
    where T : IWithDepth<T>
{
    public override SingleModeParsingResult<T> ParseSingleMode(T builder, IEnumerator<string> enumerator,
        Context context)
    {
        int depth;
        bool result = int.TryParse(enumerator.Current, out depth);
        if (result) builder.WithDepth(depth);

        enumerator.MoveNext();

        if (Successor is null)
        {
            if (!enumerator.MoveNext()) return new SingleModeParsingResult<T>.Success(builder);

            return new SingleModeParsingResult<T>.Failure("Unable to parse an int value for flag \'-d\'");
        }

        return Successor.ParseSingleMode(builder, enumerator, context);
    }
}