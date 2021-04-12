using System.Collections.Immutable;

namespace scape.Model
{
    public record Mob(string Sym, int X, int Y);

    public record Game
    (
        ImmutableList<string> Log,
        Mob Player, 
        Mob[] Enemies,
        string LastKey
    );
}