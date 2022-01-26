using ConsoleEngineLib.Components;
using ConsoleEngineLib.Math;
using ConsoleEngineLib.Rendering;
using ConsoleEngineLib.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleEngineLib.Games
{
    public class GameObject: RenderGameLoopBase
    {
        public GameObject Clone()
        {
            return new GameObject(Name, new Vector3(Position.X,Position.Y,Position.Z), components.Select(o=>o.Clone()).ToList());
        }
        public Scene Scene { get; set; }
        protected List<Component> components { get; set; }
        public string Name { get; private set; }
        public Vector3 Position { get; set; }
        public GameObject(string name)
        {
            this.Name = name;
            this.components = new List<Component>();
            this.Position = Vector3.Zero;
        }
        public T GetComponent<T>() where T:Component
        {
            return (T)this.components
                .FirstOrDefault(o=>typeof(T)
                .IsAssignableFrom(o.GetType()));
        }
        public GameObject(string name, Vector3 position) : this(name)
        {
            this.Position = position;
        }

       
          public GameObject(string name, Vector3 position, List<Component> components) : this(name,position)
        {
            this.components = components;
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
