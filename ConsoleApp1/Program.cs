// See https://aka.ms/new-console-template for more information
using ConsoleEngineLib.Game;
using ConsoleEngineLib.Scenes;
using ConsoleEngineLib.Sprites;

var Game = new Game();



var mainMenu = Game.AddScene(getMainMenu());
Game.ChangeScene(mainMenu);
Game.Start();



Scene getMainMenu()
{
    var scene = new Scene("Main Menu");

    var title = new GameObject("Title" ,new ConsoleEngineLib.Math.Vector3Int(5, 0,1));
    title.AddComponent(new ConsoleEngineLib.Components.SpriteRendererComponent(SpriteHelper.FromText("Title"), new ConsoleEngineLib.Math.Vector2Int(0, 0)));
    title.AddComponent(new TestMoveComponent());

    var ng = new GameObject("NewGame", new ConsoleEngineLib.Math.Vector3Int(5, 1));
    ng.AddComponent(new ConsoleEngineLib.Components.SpriteRendererComponent(SpriteHelper.FromText("New Game"), new ConsoleEngineLib.Math.Vector2Int(0, 0)));


    var cg = new GameObject("ContinueGame", new ConsoleEngineLib.Math.Vector3Int(5, 2));
    cg.AddComponent(new ConsoleEngineLib.Components.SpriteRendererComponent(SpriteHelper.FromText("Continue Game"),new ConsoleEngineLib.Math.Vector2Int(0,0)));


    var eg = new GameObject("ExitGame",new ConsoleEngineLib.Math.Vector3Int(5,3));
    eg.AddComponent(new ConsoleEngineLib.Components.SpriteRendererComponent(SpriteHelper.FromText("Exit Game"), new ConsoleEngineLib.Math.Vector2Int(0, 0)));

    scene.AddGameObject(title);
    scene.AddGameObject(ng);
    scene.AddGameObject(cg);
    scene.AddGameObject(eg);


    return scene;
}