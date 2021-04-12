namespace scape
{
    abstract record Input
    {
        public record Wait : Input;
        public record Move(int DX, int DY) : Input;
    }
}