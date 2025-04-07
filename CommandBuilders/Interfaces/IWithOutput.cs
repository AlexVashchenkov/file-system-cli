using FileSystemCli.Printer;

namespace FileSystemCli.CommandBuilders.Interfaces;

public interface IWithOutput<T>
{
    public T WithOutput(IPrinter printer);
}