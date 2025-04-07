using FileSystemCli.Paths;

namespace FileSystemCli.CommandBuilders.Interfaces;

public interface IWithPath<T>
{
    public T WithPath(IPath path);
}