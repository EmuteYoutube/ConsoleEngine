using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEngineLib.Sprites
{
    public class Sprite
    {
        private char[,] data;
        public char[,] GetData() => data;
        public Sprite(char[,] data)
        {
            this.data = data;
        }
        public int Width { get { return data.GetLength(0); } }
        public int Height { get { return data.GetLength(1); } }
    }
}
