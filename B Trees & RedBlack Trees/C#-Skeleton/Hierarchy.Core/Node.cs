
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Hierarchy.Core
{
    public class Node<T> : IEnumerable<T>
    {
        private T value;
        private Node<T> parent;
        private List<Node<T>> children;
        public Node(T value)
        {
            this.value = value;
            this.parent = null;
            this.children = new List<Node<T>>();
        }
        public Node(T value, Node<T> parent)
        {
            this.value = value;
            this.parent = parent;
            this.children = new List<Node<T>>();
        }
        public T GetValue() => this.value;
        public Node<T> GetParent() => this.parent;
        public void SetParent(Node<T> parent)
        {
            this.parent = parent;
        }
        public List<Node<T>> GetChildren() 
        {
            return this.children;
        }
        public void AddChild(Node<T> child)
        {
            this.children.Add(child);
        }
        public void RemoveChild(Node<T> child) 
        {
            this.children.Remove(child);
        }
        public override string ToString()
        {
            return this.value.ToString();
        }
        public IEnumerator<T> GetEnumerator()
        {
            var queue = new Queue<Node<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var child in current.GetChildren())
                {
                    queue.Enqueue(child);
                }
                yield return current.GetValue();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
