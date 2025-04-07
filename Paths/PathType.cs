namespace FileSystemCli.Paths;

public abstract record PathType
{
    private PathType()
    {
    }

    public sealed record AbsolutePath(string Path) : PathType;

    public sealed record RelativePath(string Path) : PathType;
}