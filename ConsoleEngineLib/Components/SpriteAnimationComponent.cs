using ConsoleEngineLib.Math;
using ConsoleEngineLib.Rendering;
using ConsoleEngineLib.Sprites;
using System;
using System.Collections.Generic;

namespace ConsoleEngineLib.Components
{
    public class SpriteAnimationComponent : Component
    {

        public override Component Clone()
        {
            return new SpriteAnimationComponent(Sprites, CenterPoint);
        }

            public SpriteAnimationComponent(Sprite[] sprites, Vector2? centerPoint = null)
        {
            Sprites = sprites;
            if (centerPoint == null)
                this.CenterPoint = calculateCenterPoint(sprites[0]);
            else
                this.CenterPoint = centerPoint;
        }

        public void FrameChange()
        {
            SpriteIndex++;
            if (SpriteIndex >= Sprites.Length)
                SpriteIndex = 0;
        }

        private Vector2 calculateCenterPoint(Sprite sprite)
        {
            return new Vector2(sprite.Width / 2, sprite.Height / 2);
        }

        public Sprite[] Sprites { get; }
        public int SpriteIndex = 0;
        public Vector2 CenterPoint { get; }

        public override List<RenderChunk>? Render()
        {
            RenderChunk chunk = new RenderChunk(this.CenterPoint, this.Sprites[this.SpriteIndex].GetData());
            return new List<RenderChunk>() { chunk };
        }
    }
}
