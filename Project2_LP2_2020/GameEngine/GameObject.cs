using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;

namespace Project2_LP2_2020.GameEngine
{
    public class GameObject
    {
        public string Name { get; }
        private readonly ICollection<Component> components;
        public GameObject(string name)
        {
            this.Name = name;
            components = new List<Component>();
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
        }

        public T GetComponent<T>() where T : Component
        {
            foreach(Component component in components)
                if(component is T) return component as T;
            return null;
        }

        public IEnumerable<T> GetComponents<T>() where T : Component
        {
            foreach(Component component in components)
            {
                if(component is T) yield return component as T;
            }
        }

        public void Start()
        {
            foreach(Component component in components)
            {
                component.Start();
            }
        }

        public void Update()
        {
            foreach(Component component in components)
            {
                component.Update();
            }
        }

        public void Finish()
        {
            foreach(Component component in components)
            {
                component.Finish();
            }
        }
    }
}