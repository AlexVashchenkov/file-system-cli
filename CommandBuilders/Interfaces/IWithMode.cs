namespace FileSystemCli.CommandBuilders.Interfaces;

public interface IWithMode<T>
{
    public T WithMode(string mode);
}