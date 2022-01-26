using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleEngineLib.Rendering
{
    public class DefaultRenderer : Renderer
    {
        public static bool DebugMode = true;
        public override void Render(List<RenderChunk> ro)
        {
            Console.Clear();
            foreach (var chunk in ro.OrderBy(o => o.Position.Z))
            {
                int startX = chunk.Position.X - (chunk.CenterPoint.X / 2);
                int startY = chunk.Position.Y - (chunk.CenterPoint.Y / 2);
                for (int y = 0; y < chunk.Height; y++)
                {
                    if (DebugMode)
                    {
                        if (startX - 1 > 0)
                        {
                            Console.SetCursorPosition(startX - 1, startY + 0);
                            Console.Write('|');
                        }

                    }
                    for (int x = 0; x < chunk.Width; x++)
                    {
                        if (startX + x < 0 || startY + y < 0)
                            continue;
                       
                        Console.SetCursorPosition(startX + x, startY + y);
                        Console.Write(chunk.Data[x, y]);
                    }
                    if (DebugMode)
                    {
                        Console.SetCursorPosition(startX + chunk.Data.Length + 1, startY + 0);
                        Console.Write('|');

                    }
                      
                    
                }
                Console.SetCursorPosition(0,0);


            }
        }
    }
}
