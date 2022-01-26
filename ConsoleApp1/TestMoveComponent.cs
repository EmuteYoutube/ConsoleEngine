// See https://aka.ms/new-console-template for more information
using ConsoleEngineLib.Components;
using ConsoleEngineLib.Games;
public class TestMoveComponent : Component
{
    float dir = 1;
    public float MoveSpeed = 10f;
    public override void Update()
    {
            this.GameObject.Position.Y += dir * MoveSpeed * Game.DeltaTime;
            if (this.GameObject.Position.Y >= 30)
            {
                dir = -1;
            }

            if (this.GameObject.Position.Y <= 0)
            {
                dir = 1;
            }
        
      
        base.Update();
    }
}