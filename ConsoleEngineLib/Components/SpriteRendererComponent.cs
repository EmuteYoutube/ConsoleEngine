using ConsoleEngineLib.Math;
using ConsoleEngineLib.Rendering;
using ConsoleEngineLib.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEngineLib.Components
{
    public class SpriteRendererComponent:Component
    {
        public SpriteRendererComponent(Sprite sprite,Vector2Int? centerPoint =null)
        {
            Sprite = sprite;
            if (centerPoint == null)
                this.CenterPoint = calculateCenterPoint(sprite);
            else
                this.CenterPoint = centerPoint;
        }

        private Vector2Int calculateCenterPoint(Sprite sprite)
        {
            return new Vector2Int(sprite.Width / 2, sprite.Height / 2);
        }

        public Sprite Sprite { get; }
        public Vector2Int CenterPoint { get; }

        public override List<RenderChunk>? Render()
        {
            RenderChunk chunk = new RenderChunk(this.CenterPoint,this.Sprite.GetData());
            return new List<RenderChunk>() { chunk };
        }
    }
}
