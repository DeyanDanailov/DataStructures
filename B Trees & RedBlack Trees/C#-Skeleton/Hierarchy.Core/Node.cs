

using System.Collections.Generic;

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
        }
        public Node(T value, Node<T> parent)
        {
            this.value = value;
            this.parent = parent;
        }
    }
}
