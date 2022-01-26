using ConsoleEngineLib.Games;
using ConsoleEngineLib.Rendering;
using System;

namespace ConsoleEngineLib.Components
{
    public abstract class Component: RenderGameLoopBase
    {
        public GameObject GameObject { get; set; }

        public abstract Component Clone();
       

        public T GetComponent<T>() where T : Component
        {
            return GameObject.GetComponent<T>();
        }
        
    }
}
