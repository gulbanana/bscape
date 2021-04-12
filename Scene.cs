namespace scape.Scene
{
    public interface INode { }

    public record Room() : INode;

    public record Tile(string GraphemeCluster, int X, int Y) : INode;
}