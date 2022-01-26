// See https://aka.ms/new-console-template for more information
using ConsoleEngineLib;
using ConsoleEngineLib.Audio;
using ConsoleEngineLib.Components;
using ConsoleEngineLib.Games;
public class TestMoveComponent : Component
{
    public override Component Clone()
    {
        return new TestMoveComponent();
    }
    float dir = 1;
    public float MoveSpeed = 100f;
    DateTime nextChange = DateTime.Now.AddMilliseconds(500);
    public override void Update()
    {
        if (nextChange < DateTime.Now)
        {
            this.GetComponent<SpriteAnimationComponent>().FrameChange();
            nextChange = DateTime.Now.AddMilliseconds(500);
        }
        if (Input.GetKey(ConsoleKey.W))
        {
            AudioManager.PlaySound("Sounds/Pop.wav");
            this.GameObject.Position.Y -= MoveSpeed * Game.DeltaTime;

        }
        if (Input.GetKey(ConsoleKey.J))
        {
            GameObject.Scene.Game.ChangeScene(0);
        }
        if (Input.GetKey(ConsoleKey.S))
        {
            AudioManager.PlaySound("Sounds/Pop.wav");
            this.GameObject.Position.Y += MoveSpeed * Game.DeltaTime;
        }

        if (Input.GetKey(ConsoleKey.D))
        {
            AudioManager.PlaySound("Sounds/Pop.wav");
            this.GameObject.Position.X += MoveSpeed * Game.DeltaTime;
        }
        if (Input.GetKey(ConsoleKey.A))
        {
            AudioManager.PlaySound("Sounds/Pop.wav");
            this.GameObject.Position.X -= MoveSpeed * Game.DeltaTime;
        }

        //this.GameObject.Position.Y += dir * MoveSpeed * Game.DeltaTime;
        //if (this.GameObject.Position.Y >= 30)
        //{
        //    dir = -1;
        //}

        //if (this.GameObject.Position.Y <= 0)
        //{
        //    dir = 1;
        //}


        base.Update();
    }
}