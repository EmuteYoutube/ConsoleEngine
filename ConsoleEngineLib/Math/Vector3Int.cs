namespace ConsoleEngineLib.Math
{
    public class Vector3Int
    {
        public static readonly Vector3Int Zero = new Vector3Int(0, 0, 0);
        public Vector3Int(int x, int y, int z=0)
        {
            X = x;
            Y = y;
            Z = z;
        }


        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

    }
}
