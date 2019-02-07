using System;

namespace DataStructures
{
    public class BinarySearchTreeNode<T> where T : IComparable 
    {
        public BinarySearchTreeNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public BinarySearchTreeNode<T> Left;
        public BinarySearchTreeNode<T> Right;
    }
}