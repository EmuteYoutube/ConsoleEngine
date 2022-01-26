using ConsoleEngineLib.Rendering;
using ConsoleEngineLib.Scenes;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleEngineLib.Game
{
    public class Game : GameLoopBase
    {
        protected List<Scene> scenes = new List<Scene>();
        protected Scene? currentScene { get; set; }
        protected Renderer renderer = new DefaultRenderer();

        public void ChangeScene(int index)
        {
            this.currentScene = this.scenes[index];//TODO:Clone this
        }
        public override void Update()
        {
            currentScene?.Update();
        }
        public override void Start()
        {
            currentScene?.Start();
            while (true)
            {
                Update();
                Render();
                Thread.Sleep(500);
            }
        }
        public void Render()
        {
            var ro = currentScene?.Render();
            if (ro != null)
            {
                renderer.Render(ro);
            }
        }
        public int AddScene(Scene scene)
        {
            this.scenes.Add(scene);
            return this.scenes.IndexOf(scene);
        }

    }
}
