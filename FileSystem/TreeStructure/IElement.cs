using FileSystemCli.Visitors;

namespace FileSystemCli.FileSystem.TreeStructure;

public interface IElement
{
    public VisitState State { get; }
    public void Accept(string tabsLine, IVisitor visitor);
}