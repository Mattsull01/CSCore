using System;
using Xunit;

namespace DataStructures
{
    public class BstFixture
    {
        /* var arr = new[] { 15, 12, 2, 18, 14, 45, 16 };
         *
         *       15
         *      /  \
         *    12    18
         *   /  \   / \
         *  2   14 16  45
         *
         */



        [Fact]
        public void CanPopulateTree()
        {
            // Arrange
            var arr = new[] { 15, 12, 2, 18, 14, 45, 16 };

            // Act
            var bst = BstFixtureHelpers.CreateBst(arr);

            // Assert
            Assert.True(bst.Root.Right.Right.Value == 45);
            Assert.True(bst.Root.Right.Left.Value == 16);
            Assert.True(bst.Root.Left.Left.Value == 2);
            Assert.True(bst.Root.Left.Right.Value == 14);

        }

        [Fact]
        public void CanSearchTree()
        {
            // Arrange
            var arr = new[] { 15, 12, 2, 18, 14, 45, 16 };

            // Act
            var bst = BstFixtureHelpers.CreateBst(arr);

            // Assert
            Assert.True(bst.Search(45).Value == bst.Root.Right.Right.Value);
            Assert.True(bst.Search(16).Value == bst.Root.Right.Left.Value);
            Assert.True(bst.Search(2).Value == bst.Root.Left.Left.Value);
            Assert.True(bst.Search(14).Value == bst.Root.Left.Right.Value);
            Assert.Null(bst.Search(80));

        }

        protected class BstFixtureHelpers
        {
            public static BinarySearchTree<T> CreateBst<T>(T[] values) where T: IComparable {
                var bst = new BinarySearchTree<T>();

                foreach (var t in values)
                {
                    bst.Insert(t);
                }

                return bst;
            }
        }
    }
}
