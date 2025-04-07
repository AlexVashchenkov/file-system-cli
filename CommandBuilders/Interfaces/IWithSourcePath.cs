using FileSystemCli.Paths;

namespace FileSystemCli.CommandBuilders.Interfaces;

public interface IWithSourcePath<T>
{
    public T WithSourcePath(IPath path);
}