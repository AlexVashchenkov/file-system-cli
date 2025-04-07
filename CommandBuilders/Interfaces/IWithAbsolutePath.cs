namespace FileSystemCli.CommandBuilders.Interfaces;

public interface IWithAbsolutePath<T>
{
    public T WithAbsolutePath(string path);
}