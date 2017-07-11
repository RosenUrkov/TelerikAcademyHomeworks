using System.Collections.Generic;

namespace ReadAndBuildTree
{
    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            this.Value = value;

            this.Children = new List<TreeNode<T>>();
        }

        public T Value { get; set; }

        public IEnumerable<TreeNode<T>> Children { get; set; }
    }
}
