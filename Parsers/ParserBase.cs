using System.Collections.Generic;
using FileSystemCli.Models;

namespace FileSystemCli.Parsers;

public abstract class ParserBase<T> : IParser<T>
{
    protected IParser<T>? Successor { get; private set; }

    public IParser<T> SetNextParser(IParser<T> parser)
    {
        if (Successor is null)
            Successor = parser;
        else
            Successor.SetNextParser(parser);

        return this;
    }

    public abstract ArgumentsParsingResult<T> Parse(T builder, IEnumerator<string> enumerator, Context context);
}