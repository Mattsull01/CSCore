using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public BinarySearchTreeNode<T> Root { get; private set; }

        public BinarySearchTreeNode<T> Insert(T value)
        {
            var node = Root;
            return Root = Insert(ref node, value);
        }

        private BinarySearchTreeNode<T> Insert(ref BinarySearchTreeNode<T> currentNode, T value)
        {   
            if (currentNode == null)
            {
                currentNode = new BinarySearchTreeNode<T>(value);
                return currentNode;
            }

            if (value.CompareTo(currentNode.Value) <= 0)
            {
                Insert(ref currentNode.Left, value);
            }
            else
            {
                Insert(ref currentNode.Right, value);
            }

            return currentNode;
        }

        public BinarySearchTreeNode<T> Search(T value)
        {
            return Search(Root, value);
        }

        private BinarySearchTreeNode<T> Search(BinarySearchTreeNode<T> currentNode, T value)
        {
            if (currentNode == null)
            {
                return null;
            }

            if (currentNode.Value.CompareTo(value) == 0)
            {
                return currentNode;
            }

            if (currentNode.Left != null && value.CompareTo(currentNode.Value) <= 0)
            {
                return Search(currentNode.Left, value);
            }

            if (currentNode.Right != null)
            {
                return Search(currentNode.Right, value);
            }

            return null;
        }
    }

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
