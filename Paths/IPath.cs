namespace FileSystemCli.Paths;

public interface IPath
{
    public string Path { get; }
    public IPath ConstructPath(string path);
}