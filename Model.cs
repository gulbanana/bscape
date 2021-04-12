using System.Collections.Generic;

namespace scape.Model
{
    public record Mob(string Sym, int X, int Y);

    public record Game(Mob Player, Mob[] Enemies)
    {
        public IEnumerable<Scene.INode> CreateScene()
        {
            yield return new Scene.Room();
            yield return new Scene.Tile(Player.Sym, Player.X, Player.Y);
            foreach (var enemy in Enemies)
            {
                yield return new Scene.Tile(enemy.Sym, enemy.X, enemy.Y);
            }
        }
    }
}