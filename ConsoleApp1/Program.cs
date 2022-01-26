// See https://aka.ms/new-console-template for more information
using ConsoleEngineLib.Games;
using ConsoleEngineLib.Scenes;
using ConsoleEngineLib.Sprites;

var myGame = new Game(new ConsoleEngineLib.Window("Game Engine Test", 55, 32),30,50,60) ;



var mainMenu = myGame.AddScene(getMainMenu());
myGame.ChangeScene(mainMenu);
myGame.Start();



Scene getMainMenu()
{
    var scene = new Scene("Main Menu");

    var title = new GameObject("Title" ,new ConsoleEngineLib.Math.Vector3(5, 0,1));
    title.AddComponent(new ConsoleEngineLib.Components.SpriteRendererComponent(SpriteHelper.FromText(@"|^^^^^^^^^^^^^^^^^^^^^^^^^^^^^|
|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|
|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|
|~~~~~~~~~~CENTER~~~~~~~~~~~~~|
|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|
|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|
|_____________________________|"), new ConsoleEngineLib.Math.Vector2(0, 0)));
    title.AddComponent(new TestMoveComponent());
    

    var ng = new GameObject("NewGame", new ConsoleEngineLib.Math.Vector3(5, 1));
    ng.AddComponent(new ConsoleEngineLib.Components.SpriteRendererComponent(SpriteHelper.FromText("New Game"), new ConsoleEngineLib.Math.Vector2(0, 0)));


    var cg = new GameObject("ContinueGame", new ConsoleEngineLib.Math.Vector3(5, 2));
    cg.AddComponent(new ConsoleEngineLib.Components.SpriteRendererComponent(SpriteHelper.FromText("Continue Game"),new ConsoleEngineLib.Math.Vector2(0,0)));


    var eg = new GameObject("ExitGame",new ConsoleEngineLib.Math.Vector3(5,3));
    eg.AddComponent(new ConsoleEngineLib.Components.SpriteRendererComponent(SpriteHelper.FromText("Exit Game"), new ConsoleEngineLib.Math.Vector2(0, 0)));

    scene.AddGameObject(title);
    scene.AddGameObject(ng);
    scene.AddGameObject(cg);
    scene.AddGameObject(eg);


    return scene;
}