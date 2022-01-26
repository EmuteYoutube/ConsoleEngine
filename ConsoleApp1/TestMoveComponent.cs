// See https://aka.ms/new-console-template for more information
using ConsoleEngineLib.Components;

public class TestMoveComponent : Component
{
    int dir = 1;
    public DateTime nextTick = DateTime.Now.AddMilliseconds(500);
    public override void Update()
    {
        if(nextTick < DateTime.Now)
        {
            nextTick = DateTime.Now.AddMilliseconds(500);
            this.GameObject.Position.Y += dir;
            if (this.GameObject.Position.Y > 10)
            {
                dir = -1;
            }

            if (this.GameObject.Position.Y <= 0)
            {
                dir = 1;
            }
        }
      
        base.Update();
    }
}