using System;
using System.IO;
using FileSystemCli.FileSystem.TreeStructure;
using FileSystemCli.Models;
using FileSystemCli.Paths;
using FileSystemCli.Printer;

namespace FileSystemCli.FileSystem;

public class LocalDirectory : IDirectory
{
    public LocalDirectory(AbsolutePath currentPath)
    {
        CurrentPath = currentPath;
    }

    public AbsolutePath CurrentPath { get; private set; }

    public ExecutionResult Move(string oldPath, string newPath)
    {
        try
        {
            Directory.Move(oldPath, newPath);
        }
        catch (IOException exception)
        {
            return new ExecutionResult.Failure(exception.Message);
        }

        return new ExecutionResult.Success();
    }

    public ExecutionResult Show(string path, IPrinter printer)
    {
        var file = new FileInfo(path);

        StreamReader sr = file.OpenText();
        string? s;

        while ((s = sr.ReadLine()) != null) printer.Print(s);

        return new ExecutionResult.Success();
    }

    public bool Exists(string path)
    {
        return Directory.Exists(path);
    }

    public ExecutionResult Copy(string sourcePath, string destinationPath)
    {
        try
        {
            File.Copy(sourcePath, destinationPath);
        }
        catch (IOException exception)
        {
            return new ExecutionResult.Failure(exception.Message);
        }

        return new ExecutionResult.Success();
    }

    public ExecutionResult Delete(string path)
    {
        try
        {
            File.Delete(path);
        }
        catch (DirectoryNotFoundException e)
        {
            return new ExecutionResult.Failure(e.Message);
        }

        return new ExecutionResult.Success();
    }

    public ExecutionResult Rename(string path, string name)
    {
        Copy(path, string.Concat(path.AsSpan(0, path.LastIndexOf('\\')), "\\", name));
        Delete(path);

        return new ExecutionResult.Success();
    }

    public bool FindFile(string name)
    {
        string[] allFoundFiles = Directory.GetFiles(CurrentPath.Path, name, SearchOption.AllDirectories);

        return allFoundFiles.Length > 0;
    }

    public bool FindFolder(string name)
    {
        string[] allFoundFiles = Directory.GetFiles(CurrentPath.Path, name, SearchOption.AllDirectories);

        return allFoundFiles.Length > 0;
    }

    public bool GetPathType(string path)
    {
        return Path.IsPathRooted(path);
    }

    public TreeFolder GenerateTree(int? depth = 1)
    {
        var root = new TreeFolder(
            CurrentPath.Path.Substring(CurrentPath.Path.LastIndexOf("\\", StringComparison.Ordinal) + 1));
        return GenerateTree(root, CurrentPath.Path, depth);
    }

    private TreeFolder GenerateTree(TreeFolder element, string path, int? depth = 1)
    {
        if (depth == 0) return element;

        string[] folderNames = Directory.GetDirectories(path);
        string[] fileNames = Directory.GetFiles(path);

        foreach (string name in folderNames)
        {
            var folder = new TreeFolder(name.Substring(name.LastIndexOf('\\') + 1));
            if (!string.IsNullOrEmpty(path))
                GenerateTree(folder, name, depth - 1);

            element.AddFolder(folder);
        }

        foreach (string name in fileNames)
        {
            var file = new TreeFile(name.Substring(name.LastIndexOf('\\') + 1));

            element.AddFile(file);
        }

        return element;
    }
}