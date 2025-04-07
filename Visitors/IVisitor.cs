using FileSystemCli.FileSystem.TreeStructure;

namespace FileSystemCli.Visitors;

public interface IVisitor
{
    void VisitFile(string tabsLine, TreeFile file);
    void VisitFolder(string tabsLine, TreeFolder folder);
}