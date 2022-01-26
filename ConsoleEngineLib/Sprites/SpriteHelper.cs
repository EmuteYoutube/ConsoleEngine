using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleEngineLib.Sprites
{
    public class SpriteHelper
    {
        public static Sprite FromText(string text, char delimeter = '\n')
        {
            string[] heightPieces = text.Split(delimeter);
            var maxLength = heightPieces.Select(o => o.Length).Max();
            for(int i = 0; i < heightPieces.Length;i++)
            {
                var piece = heightPieces[i];
                if (piece.Length < maxLength)
                {
                    piece += new string(' ', maxLength - piece.Length);
                    heightPieces[i] = piece;
                }
            }
            int maxHeight = heightPieces.Length;
            ConsoleKeyInstance[,] data = new ConsoleKeyInstance[maxLength, maxHeight];
            for(int x = 0; x< maxLength; x++)
            {
                for (int y = 0; y < maxHeight; y++)
                    data[x, y] = new ConsoleKeyInstance(heightPieces[y][x]);
            }
            return new Sprite(data);
        }
    }
}
