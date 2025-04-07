using FileSystemCli.Paths;

namespace FileSystemCli.FileSystem;

public class LocalDirectoryFactory : IDirectoryFactory
{
    public IDirectory Create(string path)
    {
        return new LocalDirectory(new AbsolutePath(path));
    }
}