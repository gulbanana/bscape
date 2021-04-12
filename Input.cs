namespace scape
{
    abstract record Command
    {
        public record MoveTo(Model.Mob M, int X, int Y) : Command;
    }
}