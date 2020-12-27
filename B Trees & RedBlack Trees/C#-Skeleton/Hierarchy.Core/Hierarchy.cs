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
                throw new InvalidOperationException("Element does not exist in hierarchy!");
            }
            else if (this.nodes[element].GetChildren().Any(c => c.GetValue().Equals(child)))
            {
                throw new InvalidOperationException("Element already contains child!");
            }
        }

        public void Remove(T element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetChildren(T item)
        {
            throw new NotImplementedException();
        }

        public T GetParent(T item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            throw new NotImplementedException();
        } 

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}