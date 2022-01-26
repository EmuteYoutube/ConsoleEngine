using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleEngineLib.Sprites
{
    public class SpriteHelper
    {
        private static string SanitizeText(string text)
        {
            string s = "";
            bool isParsing = false;
            foreach(var character in text)
            {
                if (character == '%' && !isParsing)
                    isParsing = true;
                else if (character == '%' && isParsing)
                    isParsing = false;
                else if (!isParsing)
                    s += character;
            }
            return s;
        }

        private static ConsoleColor?[,] ParseTextForColors(string text, char delimeter)
        {
            var sanTxt = SanitizeText(text);
            string[] pieces = sanTxt.Split(delimeter);
            var maxWidth = pieces.Select(o => o.Length).Max();
            var data = new ConsoleColor?[pieces.Length, maxWidth];

            pieces = text.Split(delimeter);
            var color = "";
            bool isParsing = false;
            ConsoleColor? currentColor = null;

            for(int y = 0; y<pieces.Length;y++)
            {
                int x = 0;
                bool skipNext = false;
                foreach(var character in pieces[y])
                {
                    if (skipNext)
                    {
                        skipNext = false;
                        x++;
                        continue;
                    }
                    if (character == '%' && !isParsing)
                    {
                        isParsing = true;
                    }
                    else if (character == '%' && isParsing) 
                    {
                        if(color == "End")
                        {
                            currentColor = null;
                            isParsing = false;
                            color = "";
                            continue;
                        }
                        ConsoleColor consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.Replace("+",""));
                        if (color.EndsWith("+"))
                            currentColor = consoleColor;
                        else
                        {
                            data[y, x] = consoleColor;
                            skipNext = true;
                            isParsing = false;
                            color = "";
                        }
                        isParsing = false;
                        color = "";
                    }
                    else if (!isParsing)
                    {
                        data[y,x] = currentColor;
                        x++;
                    }else
                    if (isParsing)
                    {
                        color += character;
                    }

                }
            }
            return data;
        }
        public static Sprite FromText(string text, char delimeter = '\n')
        {
            var consoleColors = ParseTextForColors(text,delimeter);
            text = SanitizeText(text);
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
                {
                    data[x, y] = new ConsoleKeyInstance(heightPieces[y][x], consoleColors[y,x]);
                }
            }
            return new Sprite(data);
        }

       
    }
}
