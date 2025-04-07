namespace FileSystemCli.CommandBuilders.Interfaces;

public interface IWithDepth<T>
{
    public T WithDepth(int? depth);
}