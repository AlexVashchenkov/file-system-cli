using System.Collections.Generic;
using System.Collections.ObjectModel;
using FileSystemCli.Visitors;

namespace FileSystemCli.FileSystem.TreeStructure;

public class TreeFolder : IElement
{
    private readonly string _name;

    public TreeFolder(string name)
    {
        _name = name;
    }

    public IList<TreeFolder> Folders { get; } = new List<TreeFolder>();

    public IList<TreeFile> Files { get; } = new Collection<TreeFile>();

    public VisitState State { get; private set; } = new VisitState.NotVisited();

    public void Accept(string tabsLine, IVisitor visitor)
    {
        visitor.VisitFolder(tabsLine, this);
        State = new VisitState.Visited();
    }

    public void AddFile(TreeFile element)
    {
        Files.Add(element);
    }

    public void AddFolder(TreeFolder element)
    {
        Folders.Add(element);
    }

    public string FormattedName(string tabsLine)
    {
        return tabsLine + "# " + _name;
    }
}