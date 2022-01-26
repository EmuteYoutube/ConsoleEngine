namespace ConsoleEngineLib.Math
{
    public class Vector2Int
    {
        public static readonly Vector2Int Zero = new Vector2Int(0, 0);
        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

    }
}
