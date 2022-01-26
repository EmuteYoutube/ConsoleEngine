using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEngineLib
{
    public class Window
    {
        public Window(string title, int width, int height)
        {
            Title = title;
            Width = width;
            Height = height;
        }

        public string Title { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

    }
}
