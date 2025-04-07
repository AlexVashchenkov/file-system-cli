using System.Collections.Generic;
using FileSystemCli.Models;

namespace FileSystemCli.Parsers;

public interface IParser<T>
{
    public IParser<T> SetNextParser(IParser<T> parser);

    public ArgumentsParsingResult<T> Parse(T builder, IEnumerator<string> enumerator, Context context);
}