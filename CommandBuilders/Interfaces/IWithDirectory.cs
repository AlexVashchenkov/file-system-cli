using FileSystemCli.FileSystem;

namespace FileSystemCli.CommandBuilders.Interfaces;

public interface IWithDirectory<T>
{
    public T WithDirectory(LocalDirectoryFactory directory);
}