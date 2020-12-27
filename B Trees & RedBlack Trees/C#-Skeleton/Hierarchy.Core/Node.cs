

using System.Collections.Generic;
using System.Linq;

namespace Hierarchy.Core
{
    public class Node<T>
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
        public List<Node<T>> GetChildren() => this.children.ToList();
        public void AddChild(Node<T> child)
        {
            this.children.Add(child);
        }
        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
