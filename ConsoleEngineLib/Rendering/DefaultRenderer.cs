using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleEngineLib.Rendering
{
    public class DefaultRenderer : Renderer
    {
        public static bool DebugMode = true;
        private int lastBufferWidth = 0;
        private int lastBufferHeight = 0;
        private ConsoleKeyInstance[,] buffer;
        public override void Render(List<RenderChunk> ro, int bufferWidth, int bufferHeight)
        {
           
            if(lastBufferWidth == 0 ||lastBufferWidth != bufferWidth|| lastBufferHeight != bufferHeight)
            {
                Console.Clear();
                this.lastBufferWidth = bufferWidth;
                this.lastBufferHeight = bufferHeight;
                buffer = new ConsoleKeyInstance[bufferWidth, bufferHeight];
                for (int x = 0; x < bufferWidth; x++)
                    for (int y = 0; y < bufferWidth; y++)
                        buffer[x, y] = new ConsoleKeyInstance(' ');
            }
            var cBuffer = new ConsoleKeyInstance[bufferWidth, bufferHeight];
            for (int x = 0; x < bufferWidth; x++)
                for (int y = 0; y < bufferWidth; y++)
                    cBuffer[x, y] = new ConsoleKeyInstance(' ');
            foreach (var chunk in ro.OrderBy(o => o.Position.Z))
            {
                int startX = (int)(chunk.Position.X - (chunk.CenterPoint.X / 2));
                int startY = (int)(chunk.Position.Y - (chunk.CenterPoint.Y / 2));
                for (int y = 0; y < chunk.Height; y++)
                {
                  
                    for (int x = 0; x < chunk.Width; x++)
                    {
                        if (startX + x < 0 || startY + y < 0)
                            continue;
                        if (startX + x >= bufferWidth || startY + y >= bufferHeight)
                            continue;

                            cBuffer[startX + x, startY + y] = chunk.Data[x, y];
                       
                    }
                    
                      
                    
                }
                Console.SetCursorPosition(0,0);


            }
            for(int x = 0; x< bufferWidth; x++)
                for(int y = 0;y < bufferHeight; y++)
                {
                    if(!cBuffer[x,y].Equals(buffer[x,y]))
                    {

                        if (cBuffer[x, y].FgColor != null && cBuffer[x, y].BgColor != null)
                        {
                            var fgColor = Console.ForegroundColor;
                            var bgcolor = Console.BackgroundColor;
                            Console.ForegroundColor = cBuffer[x, y].FgColor ?? ConsoleColor.White;
                            Console.BackgroundColor = cBuffer[x, y].FgColor ?? ConsoleColor.White;
                            Console.SetCursorPosition(x, y);
                            Console.Write(cBuffer[x, y].Character);
                            Console.ForegroundColor = fgColor;
                            Console.BackgroundColor = bgcolor;

                        }
                        else
                        if (cBuffer[x, y].FgColor != null)
                        {
                            var fgColor = Console.ForegroundColor;
                            Console.ForegroundColor = cBuffer[x, y].FgColor ?? ConsoleColor.White;
                            Console.SetCursorPosition(x, y);
                            Console.Write(cBuffer[x, y].Character);
                            Console.ForegroundColor = fgColor;
                        }
                        else
                        if (cBuffer[x, y].BgColor != null)
                        {
                            var bgcolor = Console.BackgroundColor;
                            Console.BackgroundColor = cBuffer[x, y].FgColor ?? ConsoleColor.White;
                            Console.SetCursorPosition(x, y);
                            Console.Write(cBuffer[x, y].Character);
                            Console.BackgroundColor = bgcolor;
                        }
                        else
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(cBuffer[x, y].Character);
                        }

                    }
                }
            this.buffer = cBuffer;
        }
    }
}
