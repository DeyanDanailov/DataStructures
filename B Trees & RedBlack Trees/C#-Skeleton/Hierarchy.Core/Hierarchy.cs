namespace Hierarchy.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private Node<T> root;
        private Dictionary<T, Node<T>> nodes;
        public Hierarchy(T root)
        {
            this.root = new Node<T>(root);
            this.nodes = new Dictionary<T, Node<T>>();
            this.nodes[root] = this.root;
        }

        public int Count
        {
            get
            {
                return this.nodes.Count;
            }
        }

        public void Add(T element, T child)
        {
            if (!this.nodes.ContainsKey(element))
            {
                throw new ArgumentException("Element does not exist in hierarchy!");
            }
            if (this.nodes.ContainsKey(child))
            {
                throw new ArgumentException("Element already contains child!");
            }
            var parent = this.nodes[element];
            this.nodes[child] = new Node<T>(child, parent);
            parent.AddChild(this.nodes[child]);
        }

        public void Remove(T element)
        {
            if (!this.nodes.ContainsKey(element))
            {
                throw new ArgumentException("No such element!");
            }
            if (this.nodes[element].GetParent() == null)
            {
                throw new InvalidOperationException("Root can not be removed!");
            }

            var toBeRemoved = this.nodes[element];
            var parent = toBeRemoved.GetParent();
            parent.RemoveChild(toBeRemoved);
            var children = toBeRemoved.GetChildren();

            foreach (var child in children)
            {
                child.SetParent(parent);
                parent.AddChild(child);
            }
            this.nodes.Remove(element);
        }

        public IEnumerable<T> GetChildren(T item)
        {
            if (this.nodes.ContainsKey(item))
            {
                return this.nodes[item].GetChildren().Select(c => c.GetValue());
            }

            throw new ArgumentException("Element does not exists!");
        }

        public T GetParent(T item)
        {
            if (!this.nodes.ContainsKey(item))
            {
                throw new ArgumentException("No such element");
            }
            if (this.nodes[item].GetParent() == null)
            {
                return default(T);
            }
            return this.nodes[item].GetParent().GetValue();
        }

        public bool Contains(T value)
        {
            return this.nodes.ContainsKey(value);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            var commonElements = new List<T>();
            foreach (var element in this.nodes.Keys)
            {
                if (other.nodes.ContainsKey(element))
                {
                    commonElements.Add(element);
                }
            }
            return commonElements;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.root.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}