// See https://aka.ms/new-console-template for more information
using ConsoleEngineLib;
using ConsoleEngineLib.Components;
using ConsoleEngineLib.Sprites;

internal class MainMenuSceneComponent : Component
{
    public int index = 0;//new game

    public override Component Clone()
    {
        return new MainMenuSceneComponent();
    }

    public override void Update()
    {
        if (Input.GetKey(ConsoleKey.S))
        {
            index++;
        }

        if (Input.GetKey(ConsoleKey.W))
        {
            index--;
        }

        if (Input.GetKey(ConsoleKey.Enter)){
            if (index == 2)
                GameObject.Scene.Game.Close();
            if(index == 0)
            {
                GameObject.Scene.Game.ChangeScene(1);
            }
        }

        if (index > 2)
            index = 0;

        if (index <0)
            index = 2;


        if(index == 0)
        {
            GameObject.Scene.GetGameObject("NewGame").GetComponent<SpriteRendererComponent>().Sprites[0] = SpriteHelper.FromText("-> New Game");
            GameObject.Scene.GetGameObject("ContinueGame").GetComponent<SpriteRendererComponent>().Sprites[0] = SpriteHelper.FromText("   Continue Game");
            GameObject.Scene.GetGameObject("ExitGame").GetComponent<SpriteRendererComponent>().Sprites[0] = SpriteHelper.FromText("   Exit Game");


        }
        else if (index == 1)
        {
            GameObject.Scene.GetGameObject("NewGame").GetComponent<SpriteRendererComponent>().Sprites[0] = SpriteHelper.FromText("   New Game");
            GameObject.Scene.GetGameObject("ContinueGame").GetComponent<SpriteRendererComponent>().Sprites[0] = SpriteHelper.FromText("-> Continue Game");
            GameObject.Scene.GetGameObject("ExitGame").GetComponent<SpriteRendererComponent>().Sprites[0] = SpriteHelper.FromText("   Exit Game");

        }
        else if(index == 2)
        {
            GameObject.Scene.GetGameObject("NewGame").GetComponent<SpriteRendererComponent>().Sprites[0] = SpriteHelper.FromText("   New Game");
            GameObject.Scene.GetGameObject("ContinueGame").GetComponent<SpriteRendererComponent>().Sprites[0] = SpriteHelper.FromText("   Continue Game");
            GameObject.Scene.GetGameObject("ExitGame").GetComponent<SpriteRendererComponent>().Sprites[0] = SpriteHelper.FromText("-> Exit Game");

        }
    }
}