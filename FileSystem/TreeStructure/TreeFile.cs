using FileSystemCli.Visitors;

namespace FileSystemCli.FileSystem.TreeStructure;

public class TreeFile : IElement
{
    private readonly string _name;

    public TreeFile(string name)
    {
        _name = name;
    }

    public VisitState State { get; private set; } = new VisitState.NotVisited();

    public void Accept(string tabsLine, IVisitor visitor)
    {
        visitor.VisitFile(tabsLine, this);
        State = new VisitState.Visited();
    }

    public string FormattedName(string tabsLine)
    {
        return tabsLine + _name;
    }
}