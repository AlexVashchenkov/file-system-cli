using System.Collections.Generic;
using FileSystemCli.Models;

namespace FileSystemCli.Handlers;

public abstract class HandlerBase : IHandler
{
    public string FunctionName { get; protected set; } = string.Empty;
    protected IHandler? Successor { get; private set; }

    public IHandler SetNext(IHandler handler)
    {
        if (Successor is null)
            Successor = handler;
        else
            Successor.SetNext(handler);

        return this;
    }

    public abstract CommandParsingResult Handle(IEnumerator<string> enumerator, Context context);
}