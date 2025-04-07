using FileSystemCli.Paths;

namespace FileSystemCli.CommandBuilders.Interfaces;

public interface IWithDestinationPath<T>
{
    public T WithDestinationPath(IPath path);
}