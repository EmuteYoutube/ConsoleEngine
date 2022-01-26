using ConsoleEngineLib.Games;
using ConsoleEngineLib.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleEngineLib.Scenes
{
    public class Scene : RenderGameLoopBase
    {
        public Scene Clone()
        {
            return new Scene(Name, gameObjects.Select(o => o.Clone()).ToList());
        }
        public string Name { get; }

        protected List<GameObject> gameObjects = new List<GameObject>();


        public Scene(string name)
        {
            Name = name;
        }

        public Scene(string name,List<GameObject> gos):this(name)
        {
            this.gameObjects = gos;
        }
        private bool hasStarted = false;
        public Game Game { get; set; }
        public GameObject GetGameObject(string name)=>gameObjects.FirstOrDefault(o=>o.Name == name);
        public override void Update()
        {
            foreach (var go in this.gameObjects)
            {
                go.Update();
            }
        }
        public override void Start()
        {
            foreach (var go in this.gameObjects)
            {
                setupGameObject(go);
                go.Start();
            }
            hasStarted = true;
        }

      
        public void AddGameObject(GameObject go)
        {
            this.gameObjects.Add(go);
            if (hasStarted)
            {
                setupGameObject(go);

                go.Start();
            }
        }
        private void setupGameObject(GameObject gameObject)
        {
            gameObject.Scene = this;
        }

        public override List<RenderChunk>? Render()
        {
            List<RenderChunk> chunks = new List<RenderChunk>();
            foreach (var go in this.gameObjects)
            {
                var c = go.Render();
                if (c != null)
                    chunks.AddRange(c);
            }
            if (chunks.Count > 0)
                return chunks;
            return null;
        }
        public void AddComponent(GameObject go)
        {
            this.gameObjects.Add(go);
         
            if (hasStarted)
            {
                setupGameObject(go);
                go.Start();
            }
        }

       
    }
}
