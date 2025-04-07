using System;
using System.Collections.Generic;
using System.Linq;
using FileSystemCli.Handlers;
using FileSystemCli.Models;

namespace FileSystemCli;

public static class Program
{
    private static IHandler Handler { get; } = new MasterHandler();

    public static void Main()
    {
        var context = new Context();

        while (true)
        {
            var str = Console.ReadLine()?.Split(' ').ToList();
            if (str is null) return;

            IEnumerator<string> enumerator = str.GetEnumerator();
            enumerator.MoveNext();

            var commandParsingResult = Handler.Handle(enumerator, context);
            switch (commandParsingResult)
            {
                case CommandParsingResult.Success successResult:
                {
                    var executionResult = successResult.Command.Execute(context);
                    if (executionResult is ExecutionResult.Failure failureResult)
                        Console.WriteLine(failureResult.Message);

                    break;
                }

                case CommandParsingResult.Failure failureResult:
                    Console.WriteLine(failureResult.Message);
                    break;
            }
        }
    }
}