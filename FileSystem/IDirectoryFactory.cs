namespace FileSystemCli.FileSystem;

public interface IDirectoryFactory
{
    public IDirectory Create(string path);
}