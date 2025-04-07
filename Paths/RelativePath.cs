namespace FileSystemCli.Paths;

public class RelativePath : IPath
{
    public RelativePath(string path)
    {
        Path = path;
    }

    public string Path { get; private set; }

    public IPath ConstructPath(string path)
    {
        Path += "\\" + path;
        return this;
    }
}