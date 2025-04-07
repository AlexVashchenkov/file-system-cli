namespace FileSystemCli.Paths;

public class AbsolutePath : IPath
{
    public AbsolutePath(string path)
    {
        Path = path;
    }

    public string Path { get; private set; }

    public IPath ConstructPath(string path)
    {
        Path = path;
        return this;
    }
}