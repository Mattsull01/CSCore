using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    /// <summary>
    /// Standard BST
    /// Implemented: Insertion, Search
    /// TODO: Deletion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> where T : IComparable
    {
        public BinarySearchTreeNode<T> Root { get; private set; }

        /// <summary>
        /// Transverses the tree and returns the item if found
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Item or null</returns>
        public BinarySearchTreeNode<T> Search(T value)
        {
            return Search(Root, value);
        }

        /// <summary>
        /// Inserts and returns item
        /// </summary>
        /// <param name="value">Item value to be inserted</param>
        /// <returns></returns>
        public BinarySearchTreeNode<T> Insert(T value)
        {
            var node = Root;
            return Root = Insert(ref node, value);
        }

        // TODO: Implement
        public bool Delete(T value)
        {
            throw new NotImplementedException("Not yet implemented");
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
    }
}
