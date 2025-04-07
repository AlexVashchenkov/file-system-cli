using System.Collections.Generic;
using FileSystemCli.CommandBuilders.Interfaces;
using FileSystemCli.Models;
using FileSystemCli.Paths;

namespace FileSystemCli.Parsers.Arguments;

public class PathParser<T> : ParserBase<T>
    where T : IWithPath<T>
{
    public override ArgumentsParsingResult<T> Parse(T builder, IEnumerator<string> enumerator, Context context)
    {
        if (enumerator.Current is null) return new ArgumentsParsingResult<T>.Failure("No path was provided");

        if (context.Directory is null) return new ArgumentsParsingResult<T>.Failure("No directory found");

        if (context.Directory.GetPathType(enumerator.Current))
            builder.WithPath(new AbsolutePath(enumerator.Current));
        else
            builder.WithPath(new RelativePath(enumerator.Current));

        enumerator.MoveNext();

        if (Successor is null)
        {
            if (!enumerator.MoveNext()) return new ArgumentsParsingResult<T>.Success(builder);

            return new ArgumentsParsingResult<T>.Failure("Path argument parsing error: unable to parse");
        }

        return Successor.Parse(builder, enumerator, context);
    }
}