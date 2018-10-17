using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public BinaryTreeNode<T> Root { get; private set; }

        public BinaryTreeNode<T> Insert(T value)
        {
            var node = Root;

            // Check if root is null, if so, set root before returning insert value,
            // otherwise return insert value directly
            return Root == null ? Root = Insert(ref node, value) : Insert(ref node, value);
        }

        private BinaryTreeNode<T> Insert(ref BinaryTreeNode<T> currentNode, T value)
        {   
            // Handle when the root or a leaf is null
            if (currentNode == null)
            {
                currentNode = new BinaryTreeNode<T>(value);
                return currentNode;
            }

            // FYI: CompareTo() Returns -1,0,1 (lesser/Equal/Greater)

            // Recursively call this method with either left child node
            // when value is less then currentNode.Value or with the right child when value is greater then the currentNode.Value.
            // When we hit a null value, the null root/leaf operation above will handle and return
            if (value.CompareTo(currentNode.Value) <= 0)
            {
                Insert(ref currentNode.Left, value);
            }
            else
            {
                Insert(ref currentNode.Right, value);
            }

            // TODO: We should never make it this far, currently, returning null so that the caller can handle this for now
            return null;
        }

        public BinaryTreeNode<T> Search(T value)
        {
            return Search(Root, value);
        }

        private BinaryTreeNode<T> Search(BinaryTreeNode<T> currentNode, T value)
        {
            // If we make it to a null leaf, the value was not found
            if (currentNode == null)
            {
                return null;
            }

            // Found the first value ... return
            if (currentNode.Value.CompareTo(value) == 0)
            {
                return currentNode;
            }

            // CompareTo() Returns -1,0,1 (lesser/Equal/Greater)

            // We recursively call this method with either the left child node
            // when currentNode.Value less then or equal to the parameter value
            // or with the right child when value is greater then the currentNode.Value
            // We will continue to transverse the tree until we hit a null or find the value
            if (currentNode.Left != null && value.CompareTo(currentNode.Value) <= 0)
            {
                return Search(currentNode.Left, value);
            }

            if (currentNode.Right != null)
            {
                return Search(currentNode.Right, value);
            }
            
            // We return null when the value doesn't match and we have no more child nodes to transverse
            return null;
        }

        public BinaryTreeNode<T> Delete(T value)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
        public int GetTreeDepth()
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        private void Balance()
        {
            // TODO: Implement
        }
    }

    public class BinaryTreeNode<T> where T : IComparable 
    {
        public T Value { get; private set; }
        public BinaryTreeNode<T> Left;
        public BinaryTreeNode<T> Right;


        public BinaryTreeNode(T value)
        {
            SetValue(value);
        }
        
        public void SetValue(T value)
        {
            this.Value = value;
        }
    }
}
