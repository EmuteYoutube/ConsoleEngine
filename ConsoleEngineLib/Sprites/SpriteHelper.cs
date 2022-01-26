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
            foreach (var piece in heightPieces)
            {
                if (piece.Length < maxLength)
                {

                }
            }
            int maxHeight = heightPieces.Length;
            char[,] data = new char[maxLength, maxHeight];
            for(int x = 0; x< maxLength; x++)
            {
                for (int y = 0; y < maxHeight; y++)
                    data[x, y] = heightPieces[y][x];
            }
            return new Sprite(data);
        }
    }
}
