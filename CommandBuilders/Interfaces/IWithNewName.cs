namespace FileSystemCli.CommandBuilders.Interfaces;

public interface IWithNewName<T>
{
    public T WithNewName(string name);
}