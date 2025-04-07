using System.Linq;
using FileSystemCli.FileSystem.TreeStructure;
using FileSystemCli.Models;
using FileSystemCli.Printer;

namespace FileSystemCli.Visitors;

public class Visitor : IVisitor
{
    private readonly IPrinter _printer;
    private readonly Characters _characters;

    public Visitor(IPrinter printer)
    {
        _printer = printer;
        _characters = new Characters();
    }

    public void VisitFile(string tabsLine, TreeFile file)
    {
        _printer.Print(file.FormattedName(tabsLine));
    }

    public void VisitFolder(string tabsLine, TreeFolder folder)
    {
        _printer.Print(folder.FormattedName(tabsLine));

        if (tabsLine.Length >= 4 && tabsLine.Substring(tabsLine.Length - 4) == _characters.LastItem)
        {
            tabsLine = tabsLine.Remove(tabsLine.Length - 4);
            tabsLine += _characters.EmptyTab;
        }

        if (tabsLine.Length >= 4 && tabsLine.Substring(tabsLine.Length - 4) == _characters.VariousItem)
        {
            tabsLine = tabsLine.Remove(tabsLine.Length - 4);
            tabsLine += _characters.LineTab;
        }

        if (folder.Folders.Count > 0)
            foreach (TreeFile file in folder.Files)
                file.Accept(tabsLine + _characters.LineTab, this);
        else
            foreach (TreeFile file in folder.Files)
                file.Accept(tabsLine + _characters.EmptyTab, this);

        if (folder.Files.Count > 0)
            _printer.Print(folder.Folders.Count > 0 ? tabsLine + _characters.LineTab : tabsLine + _characters.EmptyTab);

        foreach (TreeFolder subFolder in folder.Folders)
            if (subFolder != folder.Folders.Last())
                subFolder.Accept(tabsLine + _characters.VariousItem, this);
            else
                subFolder.Accept(tabsLine + _characters.LastItem, this);
    }
}