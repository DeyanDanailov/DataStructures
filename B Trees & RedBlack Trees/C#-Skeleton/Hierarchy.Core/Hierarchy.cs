namespace Hierarchy.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

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
            throw new NotImplementedException();
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