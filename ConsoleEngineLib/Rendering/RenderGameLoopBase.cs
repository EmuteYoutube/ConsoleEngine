using ConsoleEngineLib.Game;
using System.Collections.Generic;

namespace ConsoleEngineLib.Rendering
{
    public abstract class RenderGameLoopBase : GameLoopBase
    {
        public virtual List<RenderChunk>? Render()
        {
            return null;
        }
    }
}
