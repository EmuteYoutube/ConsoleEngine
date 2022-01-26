namespace ConsoleEngineLib.Math
{
    public class Vector3
    {
        public static readonly Vector3 Zero = new Vector3(0, 0, 0);
        public Vector3(float x, float y, float z =0)
        {
            X = x;
            Y = y;
            Z = z;
        }


        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

    }
}
