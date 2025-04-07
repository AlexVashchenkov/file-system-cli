using System.Collections.Generic;
using FileSystemCli.Models;

namespace FileSystemCli.Handlers;

public interface IHandler
{
    public IHandler SetNext(IHandler handler);

    public CommandParsingResult Handle(IEnumerator<string> enumerator, Context context);
}