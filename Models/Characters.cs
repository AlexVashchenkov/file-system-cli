namespace FileSystemCli.Models;

public record Characters
{
    private readonly string horizontalLineChar = "═";
    private readonly string lastItemChar = "╚";
    private readonly string spaceChar = " ";
    private readonly string variousItemChar = "╠";
    private readonly string verticalLineChar = "║";

    public string EmptyTab => spaceChar + spaceChar + spaceChar + spaceChar;
    public string LineTab => verticalLineChar + spaceChar + spaceChar + spaceChar;
    public string LastItem => lastItemChar + horizontalLineChar + horizontalLineChar + horizontalLineChar;
    public string VariousItem => variousItemChar + horizontalLineChar + horizontalLineChar + horizontalLineChar;
}