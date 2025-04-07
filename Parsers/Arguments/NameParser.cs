using System.Collections.Generic;
using FileSystemCli.CommandBuilders.Interfaces;
using FileSystemCli.Models;

namespace FileSystemCli.Parsers.Arguments;

public class NameParser<T> : ParserBase<T>
    where T : IWithNewName<T>
{
    public override ArgumentsParsingResult<T> Parse(T builder, IEnumerator<string> enumerator, Context context)
    {
        builder.WithNewName(enumerator.Current);

        enumerator.MoveNext();

        if (Successor is null)
        {
            if (!enumerator.MoveNext()) return new ArgumentsParsingResult<T>.Success(builder);

            return new ArgumentsParsingResult<T>.Failure("Flag argument parsing error: unable to parse");
        }

        return Successor.Parse(builder, enumerator, context);
    }
}