namespace FileSystemCli.Visitors;

public record VisitState
{
    private VisitState()
    {
    }

    public sealed record NotVisited : VisitState;

    public sealed record Visited : VisitState;
}