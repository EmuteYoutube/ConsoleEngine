using ConsoleEngineLib.Math;
using ConsoleEngineLib.Sprites;
using System;
using System.Text;

namespace ConsoleEngineLib.Components
{
    public class SpriteRendererComponent : SpriteAnimationComponent
    {
        public SpriteRendererComponent(Sprite sprite, Vector2? centerPoint = null) : base(new Sprite[] { sprite}, centerPoint)
        {
            this.sprite = sprite;
        }

        private Sprite sprite { get; }

        public override Component Clone()
        {
            return new SpriteRendererComponent(sprite, CenterPoint);
        }
    }
}
