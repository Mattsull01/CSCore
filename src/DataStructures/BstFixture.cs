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
        public void ShouldPopulateTree()
        {
            // Arrange
            var arr = new[] { 15, 12, 2, 18, 14, 45, 16 };

            // Act
            var bst = BstFixtureHelpers.CreateBst(arr);

            // Assert
            Assert.Equal(45, bst.Root.Right.Right.Value);
            Assert.Equal(16, bst.Root.Right.Left.Value);
            Assert.Equal(2, bst.Root.Left.Left.Value);
            Assert.Equal(14, bst.Root.Left.Right.Value);
        }

        [Fact]
        public void ShouldSearchTree()
        {
            // Arrange
            var arr = new[] { 15, 12, 2, 18, 14, 45, 16 };

            // Act
            var bst = BstFixtureHelpers.CreateBst(arr);

            // Assert
            Assert.Equal(bst.Root.Right.Right.Value, bst.Search(45).Value);
            Assert.Equal(bst.Root.Right.Left.Value, bst.Search(16).Value);
            Assert.Equal(bst.Root.Left.Left.Value, bst.Search(2).Value);
            Assert.Equal(bst.Root.Left.Right.Value, bst.Search(14).Value);
            Assert.Null(bst.Search(80));

        }

        /// <summary>
        /// This test was built to test for a suspected bug and enforce the fix
        /// </summary>
        [Fact]
        public void ShouldntChangeRootOnInsert()
        {
            // Arrange
            var arr = new[] { 15, 12, 2, 18, 14, 45, 16 };
            
            // Act
            var bst = BstFixtureHelpers.CreateBst(arr);

            // Assert
            Assert.Equal(15, bst.Root.Value);
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
