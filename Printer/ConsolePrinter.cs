using System;

namespace FileSystemCli.Printer;

public class ConsolePrinter : IPrinter
{
    public void Print(string str)
    {
        Console.WriteLine(str);
    }
}