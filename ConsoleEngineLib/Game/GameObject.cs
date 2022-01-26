using ConsoleEngineLib.Components;
using ConsoleEngineLib.Math;
using ConsoleEngineLib.Rendering;
using ConsoleEngineLib.Scenes;
using System.Collections.Generic;

namespace ConsoleEngineLib.Game
{
    public class GameObject: RenderGameLoopBase
    {
        public Scene Scene { get; set; }
        protected List<Component> components { get; set; }
        public string Name { get; private set; }
        public Vector3Int Position { get; set; }
        public GameObject(string name)
        {
            this.Name = name;
            this.components = new List<Component>();
            this.Position = Vector3Int.Zero;
        }

        public GameObject(string name,Vector3Int position): this(name)
        { 
            this.Position = position;
        }
        private bool hasStarted = false;
     
        public void AddComponent(Component component)
        {
            this.components.Add(component);
            if (hasStarted)
            {
                setupComponent(component);

                component.Start();
            }
        }
        private void setupComponent(Component component)
        {
            component.GameObject = this;
        }
        public override void Update()
        {
            foreach (var component in this.components)
            {
                component.Update();
            }
        }
        public override void Start()
        {
            foreach (var component in this.components)
            {
                setupComponent(component);
                component.Start();
            }
            hasStarted = true;
        }

        public override List<RenderChunk>? Render()
        {
            List<RenderChunk> chunks = new List<RenderChunk>();
            foreach (var component in this.components)
            {
                var c = component.Render();
                if (c != null)
                {
                    foreach(var chunk in c)
                    {
                        chunk.Position = this.Position;
                    }
                    chunks.AddRange(c);
                }
            }
            if (chunks.Count > 0)
                return chunks;
            return null;
        }
    }
}
