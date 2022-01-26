using ConsoleEngineLib.Math;

namespace ConsoleEngineLib.Rendering
{
    public class RenderChunk
    {
        public RenderChunk(Vector3 position, Vector2 centerPoint, ConsoleKeyInstance[,] data)
        {
            Position = position;
            CenterPoint = centerPoint;
            Data = data;
        }


        public RenderChunk(Vector2 centerPoint, ConsoleKeyInstance[,] data)
        {
            Position = Vector3.Zero;
            CenterPoint = centerPoint;
            Data = data;
        }

        public Vector3 Position { get; set; }
        public Vector2 CenterPoint { get; set; }
        public ConsoleKeyInstance[,] Data { get; private set; }
        public int Width { get { return Data.GetLength(0); } }
        public int Height { get { return Data.GetLength(1); } }

    }
}
