using FileSystemCli.FileSystem.TreeStructure;
using FileSystemCli.Models;
using FileSystemCli.Printer;

namespace FileSystemCli.FileSystem;

public interface IDirectory
{
    public bool GetPathType(string path);

    public ExecutionResult Copy(string sourcePath, string destinationPath);

    public ExecutionResult Delete(string path);

    public bool FindFile(string name);

    public bool FindFolder(string name);

    public TreeFolder GenerateTree(int? depth = 1);

    public ExecutionResult Move(string oldPath, string newPath);

    public ExecutionResult Rename(string path, string name);

    public ExecutionResult Show(string path, IPrinter printer);

    public bool Exists(string path);
}