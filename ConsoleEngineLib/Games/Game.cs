using ConsoleEngineLib.Audio;
using ConsoleEngineLib.Rendering;
using ConsoleEngineLib.Scenes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ConsoleEngineLib.Games
{
    public class Game : GameLoopBase
    {
        protected List<Scene> scenes = new List<Scene>();
        protected Scene? currentScene { get; set; }
        public int Fps { get; }
        DateTime nextTick = DateTime.Now;
        private readonly Window window;
        private readonly int viewPortHeight;
        private readonly int viewPortWidth;

        public void Close()
        {
            this.isGameRunning = false;
        }

        protected Renderer renderer = new DefaultRenderer();
        private bool isGameRunning = true;
        public Game(Window window, int viewPortHeight,int viewPortWidth,int fps = 30)
        {
            this.window = window;
            this.viewPortHeight = viewPortHeight;
            this.viewPortWidth = viewPortWidth;
            Fps = fps;
            msPerTick = 1000 / fps;
            resetWindow();

        }

        private void resetWindow(bool viewFrame=false)
        {
            Console.Title = window.Title;
            Console.SetWindowSize(window.Width, window.Height);
             bufferWidth = Console.BufferWidth;
             bufferHeight = Console.BufferHeight;
            if (viewFrame)
            {
                for (int x = 0; x < viewPortWidth; x++)
                {
                    for (int y = 0; y < viewPortHeight; y++)
                    {
                        if (x == 0 || x == viewPortWidth - 1 || y == 0 || y == viewPortHeight - 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write("■");
                        }
                        else
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(" ");
                        }

                    }
                }
                Thread.Sleep(1000);
            }
            
        }

        private int msPerTick;
        private Thread renderThread;
        private Thread inputThread;

        public void ChangeScene(int index)
        {
            this.currentScene = this.scenes[index].Clone();//TODO:Clone this
            currentScene.Game = this;
            currentScene?.Start();
        }
        public override void Update()
        {
            currentScene?.Update();
        }
        public override void Start()
        {
            this.renderThread = new Thread(new ThreadStart(renderThreadTick));
            this.inputThread = new Thread(new ThreadStart(inputThreadTick));
            renderThread.Start();
            inputThread.Start();
        }
        private List<ConsoleKeyInfo> inputs = new List<ConsoleKeyInfo>();
        private void inputThreadTick()
        {
            while (isGameRunning)
            { 
                var key = Console.ReadKey(true);
                lock (inputs)
                {
                    inputs.Add(key);
                }
            }
        }

        private int tickNum = 0;
        private int bufferWidth;
        private int bufferHeight;
        public static float DeltaTime { get; private set; }
        private void renderThreadTick()
        {
            currentScene.Game = this;
            currentScene?.Start();
            nextTick = DateTime.Now.AddMilliseconds(msPerTick);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (isGameRunning)
            {
                if (nextTick < DateTime.Now)
                {
                    tickNum++;
                    if (tickNum % 100 == 55)
                        resetWindow();

                    lock (inputs)
                    {
                        Input.SetKeys(inputs.ToArray());
                        inputs.Clear();
                    }

                    DeltaTime = (float)((float)sw.ElapsedMilliseconds / 1000.0f);
                    sw.Restart();
                    AudioManager.PlayQueue();
                    Update();
                    Render();
                    Input.ClearKeys();
                    
                    nextTick = nextTick.AddMilliseconds(msPerTick);
                    var msOffset = nextTick - DateTime.Now;
                    if (msOffset.TotalMilliseconds > 0)
                        Thread.Sleep(msOffset.Milliseconds);
                }
                
            }
        }

        public void Render()
        {
            var ro = currentScene?.Render();
            if (ro != null)
            {
                renderer.Render(ro,bufferWidth,bufferHeight);
            }
        }
        public int AddScene(Scene scene)
        {
            this.scenes.Add(scene);
            return this.scenes.IndexOf(scene);
        }

    }
}
