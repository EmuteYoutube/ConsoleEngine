using ConsoleEngineLib.Math;

namespace ConsoleEngineLib.Rendering
{
    public class RenderChunk
    {
        public RenderChunk(Vector3Int position, Vector2Int centerPoint, char[,] data)
        {
            Position = position;
            CenterPoint = centerPoint;
            Data = data;
        }


        public RenderChunk(Vector2Int centerPoint, char[,] data)
        {
            Position = Vector3Int.Zero;
            CenterPoint = centerPoint;
            Data = data;
        }

        public Vector3Int Position { get; set; }
        public Vector2Int CenterPoint { get; set; }
        public char[,] Data { get; private set; }
        public int Width { get { return Data.GetLength(0); } }
        public int Height { get { return Data.GetLength(1); } }

    }
}
