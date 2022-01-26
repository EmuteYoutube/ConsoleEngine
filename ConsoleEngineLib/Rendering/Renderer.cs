using System.Collections.Generic;

namespace ConsoleEngineLib.Rendering
{
    public abstract class Renderer
    {
        public abstract void Render(List<RenderChunk> ro);
    }
}
